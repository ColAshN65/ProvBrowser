using System.Text.Json.Serialization;

namespace ApiConnector.AssemblyUi.Responses;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public class AutoHighlightsResult
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("results")]
    public List<ResultDto> Results { get; set; }
}

public class Chapter
{
    [JsonPropertyName("gist")]
    public string Gist { get; set; }

    [JsonPropertyName("headline")]
    public string Headline { get; set; }

    [JsonPropertyName("summary")]
    public string Summary { get; set; }

    [JsonPropertyName("start")]
    public int? Start { get; set; }

    [JsonPropertyName("end")]
    public int? End { get; set; }
}

public class ContentSafetyLabels
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("results")]
    public List<ResultDto> Results { get; set; }

    [JsonPropertyName("summary")]
    public Summary Summary { get; set; }

    [JsonPropertyName("severity_score_summary")]
    public SeverityScoreSummary SeverityScoreSummary { get; set; }
}

public class Disasters
{
    [JsonPropertyName("low")]
    public double? Low { get; set; }

    [JsonPropertyName("medium")]
    public double? Medium { get; set; }

    [JsonPropertyName("high")]
    public int? High { get; set; }
}

public class Entity
{
    [JsonPropertyName("entity_type")]
    public string EntityType { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("start")]
    public int? Start { get; set; }

    [JsonPropertyName("end")]
    public int? End { get; set; }
}

public class HealthIssues
{
    [JsonPropertyName("low")]
    public double? Low { get; set; }

    [JsonPropertyName("medium")]
    public double? Medium { get; set; }

    [JsonPropertyName("high")]
    public double? High { get; set; }
}

public class IabCategoriesResult
{
    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("results")]
    public List<ResultDto> Results { get; set; }

    [JsonPropertyName("summary")]
    public Summary Summary { get; set; }
}

public class LabelDto
{
    [JsonPropertyName("label")]
    public string Label { get; set; }

    [JsonPropertyName("confidence")]
    public double? Confidence { get; set; }

    [JsonPropertyName("severity")]
    public double? Severity { get; set; }

    [JsonPropertyName("relevance")]
    public double? Relevance { get; set; }
}

public class ResultDto
{
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("rank")]
    public double? Rank { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("timestamps")]
    public List<Timestamp> Timestamps { get; set; }

    [JsonPropertyName("labels")]
    public List<LabelDto> Labels { get; set; }

    [JsonPropertyName("sentences_idx_start")]
    public int? SentencesIdxStart { get; set; }

    [JsonPropertyName("sentences_idx_end")]
    public int? SentencesIdxEnd { get; set; }

    [JsonPropertyName("timestamp")]
    public Timestamp Timestamp { get; set; }
}

public class StartTranscribeResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("audio_url")]
    public string AudioUrl { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("webhook_auth")]
    public bool? WebhookAuth { get; set; }

    [JsonPropertyName("auto_highlights")]
    public bool? AutoHighlights { get; set; }

    [JsonPropertyName("redact_pii")]
    public bool? RedactPii { get; set; }

    [JsonPropertyName("summarization")]
    public bool? Summarization { get; set; }

    [JsonPropertyName("language_model")]
    public string LanguageModel { get; set; }

    [JsonPropertyName("acoustic_model")]
    public string AcousticModel { get; set; }

    [JsonPropertyName("language_code")]
    public string LanguageCode { get; set; }

    [JsonPropertyName("language_detection")]
    public bool? LanguageDetection { get; set; }

    [JsonPropertyName("language_confidence_threshold")]
    public double? LanguageConfidenceThreshold { get; set; }

    [JsonPropertyName("language_confidence")]
    public double? LanguageConfidence { get; set; }

    [JsonPropertyName("speech_model")]
    public string SpeechModel { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("words")]
    public List<Word> Words { get; set; }

    [JsonPropertyName("utterances")]
    public List<Utterance> Utterances { get; set; }

    [JsonPropertyName("confidence")]
    public double? Confidence { get; set; }

    [JsonPropertyName("audio_duration")]
    public int? AudioDuration { get; set; }

    [JsonPropertyName("punctuate")]
    public bool? Punctuate { get; set; }

    [JsonPropertyName("format_text")]
    public bool? FormatText { get; set; }

    [JsonPropertyName("disfluencies")]
    public bool? Disfluencies { get; set; }

    [JsonPropertyName("multichannel")]
    public bool? Multichannel { get; set; }

    [JsonPropertyName("audio_channels")]
    public int? AudioChannels { get; set; }

    [JsonPropertyName("webhook_url")]
    public string WebhookUrl { get; set; }

    [JsonPropertyName("webhook_status_code")]
    public int? WebhookStatusCode { get; set; }

    [JsonPropertyName("webhook_auth_header_name")]
    public string WebhookAuthHeaderName { get; set; }

    [JsonPropertyName("auto_highlights_result")]
    public AutoHighlightsResult AutoHighlightsResult { get; set; }

    [JsonPropertyName("audio_start_from")]
    public int? AudioStartFrom { get; set; }

    [JsonPropertyName("audio_end_at")]
    public int? AudioEndAt { get; set; }

    [JsonPropertyName("boost_param")]
    public string BoostParam { get; set; }

    [JsonPropertyName("filter_profanity")]
    public bool? FilterProfanity { get; set; }

    [JsonPropertyName("redact_pii_audio")]
    public bool? RedactPiiAudio { get; set; }

    [JsonPropertyName("redact_pii_audio_quality")]
    public string RedactPiiAudioQuality { get; set; }

    [JsonPropertyName("redact_pii_policies")]
    public List<string> RedactPiiPolicies { get; set; }

    [JsonPropertyName("redact_pii_sub")]
    public string RedactPiiSub { get; set; }

    [JsonPropertyName("speaker_labels")]
    public bool? SpeakerLabels { get; set; }

    [JsonPropertyName("speakers_expected")]
    public int? SpeakersExpected { get; set; }

    [JsonPropertyName("content_safety")]
    public bool? ContentSafety { get; set; }

    [JsonPropertyName("content_safety_labels")]
    public ContentSafetyLabels ContentSafetyLabels { get; set; }

    [JsonPropertyName("iab_categories")]
    public bool? IabCategories { get; set; }

    [JsonPropertyName("iab_categories_result")]
    public IabCategoriesResult IabCategoriesResult { get; set; }

    [JsonPropertyName("keyterms_prompt")]
    public List<string> KeytermsPrompt { get; set; }

    [JsonPropertyName("auto_chapters")]
    public bool? AutoChapters { get; set; }

    [JsonPropertyName("chapters")]
    public List<Chapter> Chapters { get; set; }

    [JsonPropertyName("summary_type")]
    public string SummaryType { get; set; }

    [JsonPropertyName("summary_model")]
    public string SummaryModel { get; set; }

    [JsonPropertyName("summary")]
    public string Summary { get; set; }

    [JsonPropertyName("topics")]
    public List<string> Topics { get; set; }

    [JsonPropertyName("sentiment_analysis")]
    public bool? SentimentAnalysis { get; set; }

    [JsonPropertyName("entity_detection")]
    public bool? EntityDetection { get; set; }

    [JsonPropertyName("entities")]
    public List<Entity> Entities { get; set; }

    [JsonPropertyName("speech_threshold")]
    public double? SpeechThreshold { get; set; }

    [JsonPropertyName("error")]
    public string Error { get; set; }

    [JsonPropertyName("dual_channel")]
    public bool? DualChannel { get; set; }

    [JsonPropertyName("speed_boost")]
    public bool? SpeedBoost { get; set; }

    [JsonPropertyName("word_boost")]
    public List<string> WordBoost { get; set; }

    [JsonPropertyName("prompt")]
    public string Prompt { get; set; }

    [JsonPropertyName("custom_topics")]
    public bool? CustomTopics { get; set; }
}

public class SeverityScoreSummary
{
    [JsonPropertyName("disasters")]
    public Disasters Disasters { get; set; }

    [JsonPropertyName("health_issues")]
    public HealthIssues HealthIssues { get; set; }
}

public class Summary
{
    [JsonPropertyName("disasters")]
    public double? Disasters { get; set; }

    [JsonPropertyName("health_issues")]
    public double? HealthIssues { get; set; }

    [JsonPropertyName("NewsAndPolitics>Weather")]
    public int? NewsAndPoliticsWeather { get; set; }

    [JsonPropertyName("Home&Garden>IndoorEnvironmentalQuality")]
    public double? HomeGardenIndoorEnvironmentalQuality { get; set; }

    [JsonPropertyName("Science>Environment")]
    public double? ScienceEnvironment { get; set; }

    [JsonPropertyName("BusinessAndFinance>Industries>EnvironmentalServicesIndustry")]
    public double? BusinessAndFinanceIndustriesEnvironmentalServicesIndustry { get; set; }

    [JsonPropertyName("MedicalHealth>DiseasesAndConditions>LungAndRespiratoryHealth")]
    public double? MedicalHealthDiseasesAndConditionsLungAndRespiratoryHealth { get; set; }

    [JsonPropertyName("BusinessAndFinance>Business>GreenSolutions")]
    public double? BusinessAndFinanceBusinessGreenSolutions { get; set; }

    [JsonPropertyName("NewsAndPolitics>Disasters")]
    public double? NewsAndPoliticsDisasters { get; set; }

    [JsonPropertyName("Travel>TravelLocations>PolarTravel")]
    public double? TravelTravelLocationsPolarTravel { get; set; }

    [JsonPropertyName("HealthyLiving")]
    public double? HealthyLiving { get; set; }

    [JsonPropertyName("MedicalHealth>DiseasesAndConditions>ColdAndFlu")]
    public double? MedicalHealthDiseasesAndConditionsColdAndFlu { get; set; }

    [JsonPropertyName("MedicalHealth>DiseasesAndConditions>HeartAndCardiovascularDiseases")]
    public double? MedicalHealthDiseasesAndConditionsHeartAndCardiovascularDiseases { get; set; }

    [JsonPropertyName("HealthyLiving>Wellness>SmokingCessation")]
    public double? HealthyLivingWellnessSmokingCessation { get; set; }

    [JsonPropertyName("MedicalHealth>DiseasesAndConditions>Injuries")]
    public double? MedicalHealthDiseasesAndConditionsInjuries { get; set; }

    [JsonPropertyName("BusinessAndFinance>Industries>PowerAndEnergyIndustry")]
    public double? BusinessAndFinanceIndustriesPowerAndEnergyIndustry { get; set; }

    [JsonPropertyName("MedicalHealth>DiseasesAndConditions>Cancer")]
    public double? MedicalHealthDiseasesAndConditionsCancer { get; set; }

    [JsonPropertyName("MedicalHealth>DiseasesAndConditions>Allergies")]
    public double? MedicalHealthDiseasesAndConditionsAllergies { get; set; }

    [JsonPropertyName("MedicalHealth>DiseasesAndConditions>MentalHealth")]
    public double? MedicalHealthDiseasesAndConditionsMentalHealth { get; set; }

    [JsonPropertyName("Style&Fashion>PersonalCare>DeodorantAndAntiperspirant")]
    public double? StyleFashionPersonalCareDeodorantAndAntiperspirant { get; set; }

    [JsonPropertyName("Technology&Computing>Computing>ComputerNetworking")]
    public double? TechnologyComputingComputingComputerNetworking { get; set; }

    [JsonPropertyName("MedicalHealth>DiseasesAndConditions>Injuries>FirstAid")]
    public double? MedicalHealthDiseasesAndConditionsInjuriesFirstAid { get; set; }
}

public class Timestamp
{
    [JsonPropertyName("start")]
    public int? Start { get; set; }

    [JsonPropertyName("end")]
    public int? End { get; set; }
}

public class Timestamp2
{
    [JsonPropertyName("start")]
    public int? Start { get; set; }

    [JsonPropertyName("end")]
    public int? End { get; set; }
}

public class Utterance
{
    [JsonPropertyName("confidence")]
    public double? Confidence { get; set; }

    [JsonPropertyName("start")]
    public int? Start { get; set; }

    [JsonPropertyName("end")]
    public int? End { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("words")]
    public List<Word> Words { get; set; }

    [JsonPropertyName("speaker")]
    public string Speaker { get; set; }

    [JsonPropertyName("channel")]
    public string Channel { get; set; }
}

public class Word
{
    [JsonPropertyName("confidence")]
    public double? Confidence { get; set; }

    [JsonPropertyName("start")]
    public int? Start { get; set; }

    [JsonPropertyName("end")]
    public int? End { get; set; }

    [JsonPropertyName("text")]
    public string Text { get; set; }

    [JsonPropertyName("channel")]
    public string Channel { get; set; }

    [JsonPropertyName("speaker")]
    public string Speaker { get; set; }
}

