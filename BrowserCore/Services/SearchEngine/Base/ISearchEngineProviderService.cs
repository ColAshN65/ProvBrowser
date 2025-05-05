namespace BrowserCore.Services.SearchEngine.Base;

public interface ISearchEngineProviderService
{
    public string GetHomePageUrl();

    public string GetSearchPageUrl(string searchText);
}
