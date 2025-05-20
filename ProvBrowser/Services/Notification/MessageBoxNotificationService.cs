using Services.Notification.Base;
using System.Diagnostics;
using System.Windows;

namespace ProvBrowser.Services.Notification;

public class MessageBoxNotificationService : INotificationService
{
    public void NotifyError(string message)
    {
        MessageBox.Show(message,
            "Ошибка",
            MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    public void NotifyError(string message, string description, object source)
    {
        MessageBox.Show(message + "\n" + description + "\nОбъект ошибки: " + source,
            "Ошибка",
            MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    public void NotifyException(string message, Exception ex)
    {
        MessageBox.Show(message + "\n\nException info:\n" +
            $"Source: {ex.Source}\n" +
            $"Message: {ex.Message}\n" +
            $"Data: {ex.Data.ToString()}\n",
            "Ошибка",
            MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
