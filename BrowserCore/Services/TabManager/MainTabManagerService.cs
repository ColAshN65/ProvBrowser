using BrowserCore.Model;
using BrowserCore.Services.TabManager.Base;

namespace ProvBrowser.Services.Browser;

public class MainTabManagerService : ITabManagerService
{
    public MainTabManagerService()
    {
        browserTabs = new List<BrowserTabModel>() { new BrowserTabModel(Guid.NewGuid(), "Бег", "https://www.google.ru/?hl=ru", false) };
        favoriteTabs = new List<BrowserTabModel>();
    }
    public void AddFavoriteTabModel(BrowserTabModel tabModel)
    {
        favoriteTabs.Add(tabModel);
    }

    public void AddTabModel(BrowserTabModel tabModel)
    {
        browserTabs.Add(tabModel);
    }

    public void ChangeFavoriteTabModel(BrowserTabModel tabModel)
    {
        throw new NotImplementedException();
    }

    public void ChangeTabModel(BrowserTabModel tabModel)
    {
        throw new NotImplementedException();
    }

    public void DeleteFavoriteTabModel(BrowserTabModel tabModel)
    {
        favoriteTabs.Remove(tabModel);
    }

    public IEnumerable<BrowserTabModel> GetFavoriteTabs()
    {
        return favoriteTabs;
    }

    public IEnumerable<BrowserTabModel> GetSavedTabs()
    {
        return browserTabs;
    }

    public void RemoveTabModel(BrowserTabModel tabModel)
    {

    }

    private List<BrowserTabModel> browserTabs;
    private List<BrowserTabModel> favoriteTabs;
}
