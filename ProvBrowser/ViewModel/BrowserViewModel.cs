using CefSharp.Wpf;
using MVVM.Core.Commands.Base;
using MVVM.Core.ViewModel;
using MVVM.Core.ViewModel.Base;
using ProvBrowser.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ProvBrowser.ViewModel
{
    public class BrowserViewModel : SimpleViewModel
    {
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        private string _title;
        public string Url
        {
            get => _url;
            set => Set(ref _url, value);
        }
        private string _url;

        public ChromiumWebBrowser WebBrowser { get; set; } = new ChromiumWebBrowser(); 
        public BrowserViewModel(string url)
        {
            WebBrowser.AddressChanged += test;
            Url = url;
        }

        private void test(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }

        public BaseCommand BackCommand
        {
            get => new BaseCommand((obj) =>
            {

            });
        }
        public BaseCommand ForwardCommand
        {
            get => new BaseCommand((obj) =>
            {

            });
        }
        public BaseCommand RefreshCommand
        {
            get => new BaseCommand((obj) =>
            {

            });
        }
    }
}
