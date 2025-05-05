namespace Services.Transcribing;

public class TranscribationResult
{
    public string Text { get; }

    public bool IsSuccess { get; }  


    public TranscribationResult(string text, bool isSuccess)
    {
        Text = text;
        IsSuccess = isSuccess;
    }
}
