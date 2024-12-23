using MVVM.Core.Commands.Base;
using MVVM.Core.ViewModel;
using MVVM.Core.ViewModel.Base;
using ProvBrowser.Utilities;
using ProvBrowser.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProvBrowser.ViewModel
{
    public class TabBrowserViewModel : SimpleViewModel
    {
        public VmContainerCollection BrowsersCollection { get; set; } = new VmContainerCollection();
        public TabBrowserViewModel()
        {
            BrowsersCollection.AddContainer(new VmContainer(
                    new BrowserView(),
                    new BrowserViewModel("https://www.google.ru/?hl=ru")));

        }
    }
}
