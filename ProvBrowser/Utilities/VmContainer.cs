using MVVM.Core.ViewModel;
using MVVM.Core.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProvBrowser.Utilities
{
    public class VmContainer : BaseNotifyPropertyChanged
    {
        public INotifyPropertyChanged ViewModel
        {
            get => _viewModel;
            set => Set(ref _viewModel, value);
        }

        public Control View
        {
            get => _view;
            set => Set(ref _view, value);
        }

        private INotifyPropertyChanged _viewModel;
        private Control _view;
        
        public VmContainer(Control control, INotifyPropertyChanged viewModel)
        {
            View = control;
            ViewModel = viewModel;
            control.DataContext = viewModel;
        }
    }
}
