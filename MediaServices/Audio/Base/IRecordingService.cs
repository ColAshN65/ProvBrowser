namespace WPFMediaServices.Audio.Base;

public interface IRecordingService
{
    void StartRecording();
    void StopRecording();
    string GetRecordPath();
}
