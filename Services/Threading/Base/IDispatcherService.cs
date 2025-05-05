namespace Services.Threading.Base;

/// <summary>
///     Сервис, позволяющий взаимодействовать с записанным потоком диспетчера.
/// </summary>
public interface IDispatcherService
{
    public void InvokeAsync(Action action);
}
