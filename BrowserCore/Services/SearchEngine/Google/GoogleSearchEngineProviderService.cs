using BrowserCore.Services.SearchEngine.Base;

namespace BrowserCore.Services.SearchEngine.Google;

public class GoogleSearchEngineProviderService : ISearchEngineProviderService
{
    public string GetHomePageUrl()
        => Url;

    public string GetSearchPageUrl(string searchText)
        => Url + "/search?q=" + TransformSearchText(searchText);

    private string TransformSearchText(string searchText)
    {
        return searchText.Replace(" ", "+");
    }

    static readonly string Url = "https://www.google.ru";
}
