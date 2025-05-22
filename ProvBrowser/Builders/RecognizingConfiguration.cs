using ApiConnector.AssemblyUi.Services;
using FeatureServices.Transcribing;
using FeatureServices.Transcribing.Base;
using Microsoft.Extensions.DependencyInjection;
using Services.Audio;
using SupportServices.FileManager;
using SupportServices.FileManager.Base;
using SupportServices.Notification.Base;
using WPFMediaServices.Audio.Base;

namespace ProvBrowser.Builders;

public static class RecognizingConfiguration
{
    public static IServiceCollection BuildRecognizingConfiguration(this IServiceCollection services, INotificationService notificationService, IFileManagerService fileManagerService)
    {
        string cacheFilePath = "RecordResult.wav";

        var audioServiceBuilder = new NAudioRecordingServiceBuilder(notificationService, fileManagerService);
        var transcribationService = new AssemblyUiTranscribationService(notificationService, fileManagerService, new AssemblyUiApiService(), cacheFilePath);

        services.AddSingleton(audioServiceBuilder);
        services.AddSingleton<IFileTranscribationService>(transcribationService);

        return services;
    }
}
