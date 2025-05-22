using Services.Audio;
using SupportServices.FileManager.Base;
using SupportServices.Notification.Base;
using WPFMediaServices.Audio.Base;

namespace Services.Audio;

public class NAudioRecordingServiceBuilder
{
    public NAudioRecordingServiceBuilder(INotificationService notificationService, IFileManagerService fileManagerService)
    {
        this.recordingService = notificationService;
        this.fileManagerService = fileManagerService;
    }

    public IRecordingService BuildService(Guid fileId)
       => new NAudioRecordingService(recordingService, fileManagerService, fileId);

    private readonly INotificationService recordingService;
    private readonly IFileManagerService fileManagerService;
}
