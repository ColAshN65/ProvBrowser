using ApiConnector.AssemblyUi.Services;
using FeatureServices.Transcribing;
using FeatureServices.Transcribing.Base;
using Microsoft.Extensions.DependencyInjection;
using Services.Audio;
using SupportServices.Notification.Base;
using WPFMediaServices.Audio.Base;

namespace ProvBrowser.Builders;

public static class RecognizingConfiguration
{
    public static IServiceCollection BuildRecognizingConfiguration(this IServiceCollection services, INotificationService notificationService)
    {
        string cacheFilePath = "RecordResult.wav";

        var nAudioRecordingService = new NAudioRecordingService(notificationService, cacheFilePath);
        var transcribationService = new AssemblyUiTranscribationService(notificationService, new AssemblyUiApiService(), cacheFilePath);
   
        services.AddSingleton<IRecordingService>(nAudioRecordingService);
        services.AddSingleton<ITranscribationService>(transcribationService);

        return services;
    }
}
