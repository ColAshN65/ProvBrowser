namespace WPFMediaServices.Audio.Base;

/// <summary>
///     Сервис, осуществляющий запись аудиофайлов.
/// </summary>
public interface IRecordingService : IDisposable
{
    void StartRecording();
    void StopRecording();

    /// <summary>
    ///     Возвращает имя файла, в который сервис записывает результат.
    /// </summary>
    /// <returns>Имя файла</returns>
    string GetFileName();

    /// <summary>
    ///     Возвращает полный или относительный путь до файла, в который сервис записывает результат.
    /// </summary>
    /// <returns>Путь до файла</returns>
    string GetRecordPath();
}
