using ProvBrowser.Model.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvBrowser.Services.Browser;

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
