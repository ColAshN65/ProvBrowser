using CommunityToolkit.Mvvm.ComponentModel;
using MVVM.Core.ViewModel;
using MVVM.Core.ViewModel.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ProvBrowser.Utilities
{
    public partial class VmContainerCollection : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<INotifyPropertyChanged> _viewModels;

        [ObservableProperty]
        public ObservableCollection<Control> _views;

        public VmContainerCollection(List<VmContainer> vmContainers = null)
        {
            ViewModels = new ObservableCollection<INotifyPropertyChanged>();
            Views = new ObservableCollection<Control>();

            if (vmContainers != null)
            {
                foreach (var vmContainer in vmContainers)
                {
                    AddContainer(vmContainer);
                }
            }
        }

        public void AddContainer(VmContainer vmContainer)
        {
            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;

            dispatcher.Invoke(new Action(() =>
            {
                ViewModels.Add(vmContainer.ViewModel);
                Views.Add(vmContainer.View);

                CollectionChanged?.Invoke(this, EventArgs.Empty);
            }));
        }

        public event EventHandler CollectionChanged;
    }
}
