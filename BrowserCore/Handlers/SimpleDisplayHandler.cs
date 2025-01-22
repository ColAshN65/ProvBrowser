using CefSharp;
using CefSharp.Enums;
using CefSharp.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserCore.Handlers
{
    public class SimpleDisplayHandler : IDisplayHandler
    {
        public void OnAddressChanged(IWebBrowser chromiumWebBrowser, AddressChangedEventArgs addressChangedArgs)
        {
            Debug.WriteLine("OnAddressChanged");
        }

        public bool OnAutoResize(IWebBrowser chromiumWebBrowser, IBrowser browser, Size newSize)
        {
            Debug.WriteLine("OnAutoResize");
            return true;
        }

        public bool OnConsoleMessage(IWebBrowser chromiumWebBrowser, ConsoleMessageEventArgs consoleMessageArgs)
        {
            Debug.WriteLine("OnConsoleMessage");
            return true;
        }

        public bool OnCursorChange(IWebBrowser chromiumWebBrowser, IBrowser browser, nint cursor, CursorType type, CursorInfo customCursorInfo)
        {
            Debug.WriteLine("OnCursorChange");
            return true;

        }

        public void OnFaviconUrlChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IList<string> urls)
        {
            Debug.WriteLine("OnFaviconUrlChange");
        }

        public void OnFullscreenModeChange(IWebBrowser chromiumWebBrowser, IBrowser browser, bool fullscreen)
        {
            Debug.WriteLine("OnFullscreenModeChange");
        }

        public void OnLoadingProgressChange(IWebBrowser chromiumWebBrowser, IBrowser browser, double progress)
        {
            Debug.WriteLine("OnLoadingProgressChange");
        }

        public void OnStatusMessage(IWebBrowser chromiumWebBrowser, StatusMessageEventArgs statusMessageArgs)
        {
            Debug.WriteLine("OnStatusMessage");
        }

        public void OnTitleChanged(IWebBrowser chromiumWebBrowser, TitleChangedEventArgs titleChangedArgs)
        {
            Debug.WriteLine("OnStatusMessage");
        }

        public bool OnTooltipChanged(IWebBrowser chromiumWebBrowser, ref string text)
        {
            Debug.WriteLine("OnTooltipChanged " + text);
            return true;
        }
    }
}
