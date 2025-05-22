using ApiConnector.AssemblyUi.Responses;
using ApiConnector.AssemblyUi.Services.Base;
using ApiConnector.Helpers;
using FeatureServices.Transcribing.Base;
using SupportServices.FileManager.Base;
using SupportServices.Notification.Base;
using System.IO;

namespace FeatureServices.Transcribing;

public class AssemblyUiTranscribationService : IFileTranscribationService
{
    public AssemblyUiTranscribationService(
        INotificationService notificationService,
        IFileManagerService fileManagerService,
        IAssemblyUiApiService apiService,
        string filePath)
    {
        this.notificationService = notificationService;
        this.apiService = apiService;
        this.fileManagerService = fileManagerService;
        this.filePath = filePath;
    }

    public async Task<TranscribationResult> SpeechToTextAsync(string fileName)
    {
        try
        {
            //Отправка файла в облако для дальнейшей транскрибации
            ApiResult<string> resultImageUrl;
            using (FileStream io = fileManagerService.ReadFile(fileName))
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

            //Проверка не первичный результат/ошибки
            var startStatus = ValidateResult(resultStart);
            if(startStatus is not null)
                return startStatus;

            while (true)
            {
                var result = await apiService.GetTranscript(resultStart.Value.Id);

                //Проверка на промежуточный результат/ошибки
                var resultStatus = ValidateResult(result);
                if (resultStatus is not null)
                    return resultStatus;

                await Task.Delay(300);
            }
        }
        catch (Exception ex)
        {
            notificationService.NotifyException("Возникло исключение поптке транскрибировать аудиофайл аудиофайла", ex);
        }

        return new TranscribationResult("Произошла неизвестная ошибка", false);
    }

    
    private readonly INotificationService notificationService;
    private readonly IAssemblyUiApiService apiService;
    private readonly IFileManagerService fileManagerService;
    private string filePath;

    /// <summary>
    ///     Валидирует ответ от API-сервиса. В случае успеха или ошибки вызывает notificationService и возвращает соответствующий результат.
    /// </summary>
    /// <returns>В случае статуса "queued" или "processing" возвращает null</returns>
    private TranscribationResult ValidateResult(ApiResult<StartTranscribeResponse> apiResult)
    {
        if (!apiResult.IsSuccess)
            return new TranscribationResult("Возникла ошибка при отправке запроса", false);

        if (apiResult.Value.Status == "completed")
            return GetTranscribationResult(apiResult.Value);

        else if (apiResult.Value.Status == "error")
        {
            notificationService.NotifyError("Возникла ошибка при транскрибации аудиофайла",
                                            apiResult.Value.Error,
                                            this);

            return new TranscribationResult("Возникла ошибка при транскрибации аудиофайла", false);
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    ///     Формирует результат в случае успеха.
    /// </summary>
    /// <returns>Возвращает сформированную строку</returns>
    public TranscribationResult GetTranscribationResult(StartTranscribeResponse response)
    {
        //Строка может быть уже сформирована.
        if (response.Text is not null && response.Text != "")
            return new TranscribationResult(response.Text, true);
        else
        {
            //Может бть несформирована ни строка, ни отдельно взятые слова.
            if (response.Words.Count == 0)
            {
                notificationService.NotifyError("Не удалось распознать вашу речь, попробуйте еще раз!");
                return new TranscribationResult("Произошла ошибка распознования", false);
            }

            string text = "";

            //Может быть несформирована строка, но сформированы отдельно взятые слова.
            foreach (var wordDto in response.Words)
            {
                string word = wordDto.Text;
                word.Replace(".", "");
                text += word + " ";
            }

            return new TranscribationResult(text, true);
        }
    }
}
