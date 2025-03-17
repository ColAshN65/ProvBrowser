using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvBrowser.Services.Threading;

/// <summary>
///     Сервис, позволяющий взаимодействовать с записанным потоком диспетчера.
/// </summary>
public interface IDispatcherService
{
    public void InvokeAsync(Action action);
}
