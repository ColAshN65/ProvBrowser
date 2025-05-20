using System.Windows.Threading;
using WpfLibrary.Services.Threading.Base;

namespace WpfLibrary.Services.Threading;

public class MainDispatcherService : IDispatcherService
{
    private Dispatcher dispatcher { get; }

    public MainDispatcherService(Dispatcher dispatcher)
        => this.dispatcher = dispatcher ?? throw new Exception();

    public void InvokeAsync(Action action)
        => dispatcher.InvokeAsync(action);
}
