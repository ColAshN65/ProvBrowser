using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvBrowser.Model.Browser;

public record BrowserTabModel(Guid Id, string Name, string Url, bool IsFavorite);
