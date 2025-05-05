using ApiConnector.AssemblyUi.Services;
using Microsoft.Extensions.DependencyInjection;
using ProvBrowser.Services.Notification;
using Services.Audio;
using Services.Audio.Base;
using Services.Notification.Base;
using Services.Transcribing;
using Services.Transcribing.Base;

namespace ProvBrowser.Builders;

public static class RecognizingConfiguration
{
    public static IServiceCollection BuildRecognizingConfiguration(this IServiceCollection services)
    {
        string cacheFilePath = "RecordResult.wav";

        var notificationService = new MessageBoxNotificationService();
        var nAudioRecordingService = new NAudioRecordingService(notificationService, cacheFilePath);
        var transcribationService = new AssemblyUiTranscribationService(notificationService, new AssemblyUiApiService(), cacheFilePath);

        services.AddSingleton<INotificationService>(notificationService);    
        services.AddSingleton<IRecordingService>(nAudioRecordingService);
        services.AddSingleton<ITranscribationService>(transcribationService);

        return services;
    }
}
