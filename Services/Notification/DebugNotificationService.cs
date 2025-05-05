using Services.Notification.Base;
using System.Diagnostics;

namespace Services.Notification;

public class DebugNotificationService : INotificationService
{
    public void NotifyError(string message)
    {
        Debug.WriteLine(message);
    }

    public void NotifyError(string message, string description, object source)
    {
        Debug.WriteLine(message + "\n" + description + "\nОбъект ошибки: " + source);
    }

    public void NotifyException(string message, Exception ex)
    {
        Debug.WriteLine(message + "\n\nException info:\n" +
            $"Source: {ex.Source}" +
            $"Message: {ex.Message}" +
            $"Data: {ex.Data.ToString()}");
    }
}
