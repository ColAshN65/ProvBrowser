namespace Services.Transcribing.Base;

public interface ITranscribationService
{
    public Task<TranscribationResult> SpeechToTextAsync();
}
