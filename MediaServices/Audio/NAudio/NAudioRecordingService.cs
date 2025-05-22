using NAudio.Wave;
using WPFMediaServices.Audio.Base;
using SupportServices.Notification.Base;
using SupportServices.FileManager.Base;

namespace Services.Audio;

public class NAudioRecordingService : IRecordingService
{
    public NAudioRecordingService(INotificationService notificationService, IFileManagerService fileManagerService, Guid fileId)
    {
        this.notificationService = notificationService;
        this.fileManagerService = fileManagerService;
        this.fileId = fileId;
    }

    public void StartRecording()
    { 
        waveIn = new WaveIn();
        //Встроенный микрофон имеет номер 0
        waveIn.DeviceNumber = 0;
        //Прикрепляем к событию DataAvailable обработчик, возникающий при наличии записываемых данных
        waveIn.DataAvailable += waveIn_DataAvailable;
        //Прикрепляем обработчик завершения записи
        waveIn.RecordingStopped += waveIn_RecordingStopped;
        //Формат wav-файла - принимает параметры - частоту дискретизации и количество каналов(здесь mono)
        waveIn.WaveFormat = new WaveFormat(8000, 1);

        writer = new WaveFileWriter(GetRecordPath(), waveIn.WaveFormat);
        //Начало записи
        waveIn.StartRecording();
    }

    public void StopRecording()
    {
        if (waveIn != null)
        {
            waveIn.StopRecording();
            waveIn.Dispose();
            writer.Close();
            writer.Dispose();
            writer = null;
        }
    }
    public string GetFileName()
        => $"AudioRecord_{fileId}.wav";
    public string GetRecordPath()
        => $"{fileManagerService.GetPath()}/{GetFileName()}";

    //Получение данных из входного буфера 
    void waveIn_DataAvailable(object sender, WaveInEventArgs e)
    {
        
        writer.Write(e.Buffer, 0, e.BytesRecorded);

        //fileManagerService.WriteFile(GetFileName(), e.Buffer, 0, e.BytesRecorded);
    }

    

    private INotificationService notificationService;
    private IFileManagerService fileManagerService;

    // WaveIn - поток для записи
    private WaveRecorder waveRecorder;
    private WaveIn waveIn;

    //Класс для записи в файл
    private WaveFileWriter writer;

    private readonly Guid fileId;

    //Окончание записи
    private void waveIn_RecordingStopped(object sender, EventArgs e)
    {
        waveIn.Dispose();
        waveIn = null;
    }

    public void Dispose()
    {
        StopRecording();
    }
}
