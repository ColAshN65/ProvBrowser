namespace SupportServices.FileManager.Base;

/// <summary>
///     Сервис, отвечающий за определенный формат записи и чтения файлов.
/// </summary>
public interface IFileManagerService : IDisposable
{
    /// <summary>
    ///     Инициализирует <see cref="FileStream"/>. Ответственность на закрытии файлового дескриптора лежит там, где этот метод был вызван.
    /// </summary>
    /// <param name="fileName">Имя файла</param>
    /// <returns>Возвращает экземпляр <see cref="FileStream"/></returns>
    FileStream ReadFile(string fileName);

    void WriteFile(string fileName, byte[] buffer, int offset, int count);

    /// <summary>
    ///     Позволяет получить полный или относительный путь до директории, в которой хранятся файлы сервиса.
    /// </summary>
    /// <returns>Путь к папке.</returns>
    string GetPath();
}
