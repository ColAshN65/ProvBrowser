using ApiConnector.AssemblyUi.Responses;
using ApiConnector.AssemblyUi.Services.Base;
using ApiConnector.Helpers;
using FeatureServices.Transcribing.Base;
using SupportServices.Notification.Base;
using System.IO;

namespace FeatureServices.Transcribing;

public class AssemblyUiTranscribationService : ITranscribationService
{
    public AssemblyUiTranscribationService(
        INotificationService notificationService,
        IAssemblyUiApiService apiService,
        string filePath)
    {
        this.notificationService = notificationService;
        this.apiService = apiService;
        this.filePath = filePath;
    }

    public async Task<TranscribationResult> SpeechToTextAsync()
    {
        try
        {
            //Отправка файла
            ApiResult<string> resultImageUrl;
            using (FileStream io = new FileStream(filePath, FileMode.Open))
            {
                resultImageUrl = await apiService.UploadFileAsync(io);
            }
            if (!resultImageUrl.IsSuccess)
            {
                notificationService.NotifyError("Возникла ошибка при отправке аудиофайла",
                                                resultImageUrl.Error.Code + " " + resultImageUrl.Error.Message,
                                                this);
                return new TranscribationResult(resultImageUrl.Error.Message, false);
            }

            //Транскрибация отправленного файла
            var resultStart = await apiService.StartTranscribe(resultImageUrl.Value);
            if (resultStart.IsSuccess)
            {
                //Ответ может быть получен сразу
                if (resultStart.Value.Status == "completed")
                    return GetTranscribationResult(resultStart.Value);
                else if (resultStart.Value.Status == "error")
                {
                    notificationService.NotifyError("Возникла ошибка при транскрибации аудиофайла",
                                                    resultImageUrl.Error.Code + " " + resultImageUrl.Error.Message,
                                                    this);

                    return new TranscribationResult(resultStart.Error, false);
                }

                //Периодическая проверка готовности результата
                while (true)
                {
                    var result = await apiService.GetTranscript(resultStart.Value.Id);

                    if (result.IsSuccess)
                    {
                        if (result.Value.Status == "completed")
                            return GetTranscribationResult(result.Value);
                        else if (result.Value.Status == "error")
                        {
                            notificationService.NotifyError("Возникла ошибка при транскрибации аудиофайла",
                                                            resultImageUrl.Error.Code + " " + resultImageUrl.Error.Message,
                                                            this);

                            return new TranscribationResult(result.Error, false);
                        }

                        await Task.Delay(3000);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            notificationService.NotifyException("Возникло исключение поптке транскрибировать аудиофайл аудиофайла", ex);
        }

        return new TranscribationResult("Произошла неизвестная ошибка", false);
    }

    public TranscribationResult GetTranscribationResult(StartTranscribeResponse response)
    {
        if (response.Text is not null)
            return new TranscribationResult(response.Text, true);
        else
        {
            if(response.Words.Count == 0)
                return new TranscribationResult("Произошла ошибка распознования", false);

            string text = "";

            foreach (var wordDto in response.Words)
            {
                string word = wordDto.Text;
                word.Replace(".", "");
                text += word + " ";
            }

            return new TranscribationResult(text, true);
        }
    }

    private INotificationService notificationService;
    private IAssemblyUiApiService apiService;
    private string filePath;
}
