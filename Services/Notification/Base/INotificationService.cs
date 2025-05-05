namespace Services.Notification.Base;

public interface INotificationService
{
    /// <summary>
    ///     Уведомление об ошибке с минимальным шаблоном
    /// </summary>
    public void NotifyError(string message);

    /// <summary>
    ///     Уведомление об ошибке с подробным описанием
    /// </summary>
    /// <param name="message">Основной текст</param>
    /// <param name="description">Вспомогательный текст</param>
    /// <param name="addition">Контекст ошибки</param>
    public void NotifyError(string message, string description, object source);

    /// <summary>
    ///     Уведомление о выброшенном ожидаемом исключении
    /// </summary>
    public void NotifyException(string message, Exception exception);
}
