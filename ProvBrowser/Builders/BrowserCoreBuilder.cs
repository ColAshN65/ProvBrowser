using BrowserCore.Services.SearchEngine.Base;
using BrowserCore.Services.SearchEngine.Google;
using Microsoft.Extensions.DependencyInjection;

namespace ProvBrowser.Builders;

public static class BrowserCoreBuilder
{
    public static IServiceCollection BuildBrowserCoreConfiguration(this IServiceCollection services)
    {
        services.AddSingleton<ISearchEngineProviderService, GoogleSearchEngineProviderService>();
        return services;
    }
}
