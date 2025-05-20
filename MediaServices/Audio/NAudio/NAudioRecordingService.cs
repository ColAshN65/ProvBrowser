using NAudio.Wave;
using NAudio.FileFormats;
using NAudio.CoreAudioApi;
using NAudio;
using WPFMediaServices.Audio.Base;
using SupportServices.Notification.Base;

namespace Services.Audio;

public class NAudioRecordingService : IRecordingService
{
    public NAudioRecordingService(INotificationService notificationService, string outputFilename)
    {
        this.outputFilename = outputFilename;
    }
    private void OnAsioOutAudioAvailable(object? sender, AsioAudioAvailableEventArgs e)
    {
        throw new NotImplementedException();
    }

    public void StartRecording()
    { 
        waveIn = new WaveIn();
        //Дефолтное устройство для записи (если оно имеется)
        //встроенный микрофон ноутбука имеет номер 0
        waveIn.DeviceNumber = 0;
        //Прикрепляем к событию DataAvailable обработчик, возникающий при наличии записываемых данных
        waveIn.DataAvailable += waveIn_DataAvailable;
        //Прикрепляем обработчик завершения записи
        waveIn.RecordingStopped += waveIn_RecordingStopped;
        //Формат wav-файла - принимает параметры - частоту дискретизации и количество каналов(здесь mono)
        waveIn.WaveFormat = new WaveFormat(8000, 1);
        //Инициализируем объект WaveFileWriter
        writer = new WaveFileWriter(outputFilename, waveIn.WaveFormat);
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
        }
    }

    public string GetRecordPath()
        => outputFilename;

    //Получение данных из входного буфера 
    void waveIn_DataAvailable(object sender, WaveInEventArgs e)
    {
        //Записываем данные из буфера в файл
        writer.WriteData(e.Buffer, 0, e.BytesRecorded);
    }

    private INotificationService notificationService;

    // WaveIn - поток для записи
    private WaveRecorder waveRecorder;
    private WaveIn waveIn;
    //Класс для записи в файл
    private WaveFileWriter writer;


    //Имя файла для записи
    private readonly string outputFilename;

    //Окончание записи
    private void waveIn_RecordingStopped(object sender, EventArgs e)
    {
        waveIn.Dispose();
        waveIn = null;
        writer.Close();
        writer = null;
    }
}
