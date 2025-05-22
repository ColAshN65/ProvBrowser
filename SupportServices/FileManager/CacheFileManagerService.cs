using SupportServices.FileManager.Base;

namespace SupportServices.FileManager;

/// <summary>
///     Сервис, позволяющий записывать и считывать временные файлы, а также своевременно их удалять.
/// </summary>
public class CacheFileManagerService : IFileManagerService
{
    public CacheFileManagerService(string folderName)
    {
        this.folderName = folderName;

        directoryInfo = new DirectoryInfo(folderName);

        //Создание новой папки или очистка старой, если папка уже существовала.
        if(!directoryInfo.Exists)
            directoryInfo.Create();
        else
        {
            Directory.Delete(folderName, true);
            directoryInfo.Create();
        }
    }

    public void WriteFile(string name, byte[] buffer, int offset, int count)
    {
        using (FileStream io = new FileStream($"{folderName}/{name}", FileMode.Create))
        {
            io.Write(buffer, offset, count);
        }
    }

    public FileStream ReadFile(string name) 
        => new FileStream($"{folderName}/{name}", FileMode.Open);

    public string GetPath()
        => folderName;

    public void Dispose()
    {
        //Полное удаление папки
        Directory.Delete(folderName, true);
    }

    private readonly string folderName;
    private readonly DirectoryInfo directoryInfo;
}
