namespace ApiConnector.AssemblyUi.Requests;
public class CustomSpelling
{
    public List<string>? from { get; set; }
    public string? to { get; set; }
}

public class TempReauest
{
    public string audio_url { get; set; }
    public string? language_code { get; set; }
}
public class StartTranscribeRequest
{
    public string audio_url { get; set; }
    public int? audio_end_at { get; set; }
    public int? audio_start_from { get; set; }
    public bool? auto_chapters { get; set; }
    public bool? auto_highlights { get; set; }
    public string? boost_param { get; set; }
    public bool? content_safety { get; set; }
    public List<CustomSpelling>? custom_spelling { get; set; }
    public bool? disfluencies { get; set; }
    public bool? entity_detection { get; set; }
    public bool? filter_profanity { get; set; }
    public bool? format_text { get; set; }
    public bool? iab_categories { get; set; }
    public string? language_code { get; set; }
    public double? language_confidence_threshold { get; set; }
    public bool? language_detection { get; set; }
    public bool? multichannel { get; set; }
    public bool? punctuate { get; set; }
    public bool? redact_pii { get; set; }
    public bool? redact_pii_audio { get; set; }
    public string? redact_pii_audio_quality { get; set; }
    public List<string>? redact_pii_policies { get; set; }
    public string? redact_pii_sub { get; set; }
    public bool? sentiment_analysis { get; set; }
    public bool? speaker_labels { get; set; }
    public int? speakers_expected { get; set; }
    public double? speech_threshold { get; set; }
    public bool? summarization { get; set; }
    public string? summary_model { get; set; }
    public string? summary_type { get; set; }
    public List<string>? topics { get; set; }
    public string? webhook_auth_header_name { get; set; }
    public string? webhook_auth_header_value { get; set; }
    public string? webhook_url { get; set; }
    public bool? custom_topics { get; set; }
    public bool? dual_channel { get; set; }
    public List<string>? word_boost { get; set; }
}

