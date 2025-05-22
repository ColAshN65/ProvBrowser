using BrowserCore.Model;

namespace BrowserCore.Services.TabManager.Base;

public interface ITabManagerService
{
    public IEnumerable<BrowserTabModel> GetSavedTabs();
    public void AddTabModel(BrowserTabModel tabModel);
    public void RemoveTabModel(BrowserTabModel tabModel);
    public void ChangeTabModel(BrowserTabModel tabModel);
    public IEnumerable<BrowserTabModel> GetFavoriteTabs();
    public void AddFavoriteTabModel(BrowserTabModel tabModel);
    public void ChangeFavoriteTabModel(BrowserTabModel tabModel);
    public void DeleteFavoriteTabModel(BrowserTabModel tabModel);
}
