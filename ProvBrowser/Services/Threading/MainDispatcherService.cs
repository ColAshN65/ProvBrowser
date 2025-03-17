using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ProvBrowser.Services.Threading;

public class MainDispatcherService : IDispatcherService
{
    private Dispatcher dispatcher { get; }

    public MainDispatcherService(Dispatcher dispatcher)
        => this.dispatcher = dispatcher ?? throw new Exception();

    public void InvokeAsync(Action action)
        => dispatcher.InvokeAsync(action);
}
