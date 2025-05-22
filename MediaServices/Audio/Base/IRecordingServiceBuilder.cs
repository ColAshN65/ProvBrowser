
namespace WPFMediaServices.Audio.Base;

public interface IRecordingServiceBuilder
{
    IRecordingService BuildService(Guid fileId);
}
