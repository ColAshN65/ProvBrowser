using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfLibrary.Navigation.Default;

/// <summary>
///     Обычный сервис траснформации, который пареобразует пространство имен с ViewModels в пространство имен с Views, но только в том случае, если их путь отличается на settings.ViewNamespace и они находятся в одной сборке./>
/// </summary>
public class DefaultViewNamespaceTransformer : INamespaceTransformer
{
    public DefaultViewNamespaceTransformer(DynamicNavigationSettings settings)
    {
        this.settings = settings;
    }
    public StringBuilder Transform(StringBuilder boundNamespace)
    {
        boundNamespace.Replace(settings.ViewModelNamespace, settings.ViewNamespace);
        return boundNamespace;
    }

    private DynamicNavigationSettings settings;
}
