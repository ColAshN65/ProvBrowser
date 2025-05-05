using System.Windows.Threading;
using Services.Threading.Base;

namespace Services.Threading;

public class MainDispatcherService : IDispatcherService
{
    private Dispatcher dispatcher { get; }

    public MainDispatcherService(Dispatcher dispatcher)
        => this.dispatcher = dispatcher ?? throw new Exception();

    public void InvokeAsync(Action action)
        => dispatcher.InvokeAsync(action);
}
