using MVVM.Core.ViewModel;
using MVVM.Core.ViewModel.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProvBrowser.Utilities
{
    public class VmContainerCollection
    {
        private ObservableCollection<SimpleViewModel> ViewModels { get; set; } =  new ObservableCollection<SimpleViewModel>();

        public ObservableCollection<Control> Views { get; set; } = new ObservableCollection<Control>();

        public VmContainerCollection(List<VmContainer> vmContainers = null)
        {
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
            ViewModels.Add(vmContainer.ViewModel);
            Views.Add(vmContainer.View);
        }
    }
}
