namespace FeatureServices.Transcribing.Base;

public interface IFileTranscribationService
{
    /// <summary>
    ///     Метод, который должен транскрибировать файл и вернуть <see cref="TranscribationResult"/> 
    /// </summary>
    /// <param name="fileName">Имя файла для транскрибации</param>
    /// <returns>Возвращает DTO <see cref="TranscribationResult"/>, в котором в случае ошибки св-во IsSuccess будет равно false</returns>
    public Task<TranscribationResult> SpeechToTextAsync(string fileName);
}
