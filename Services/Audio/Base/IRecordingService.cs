namespace Services.Audio.Base;

public interface IRecordingService
{
    string GetRecordPath();
    void StartRecording();
    void StopRecording();
}
