namespace FeatureServices.Transcribing.Base;

public interface ITranscribationService
{
    public Task<TranscribationResult> SpeechToTextAsync();
}
