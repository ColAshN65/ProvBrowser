using BrowserCore.Eventargs;
using CefSharp;
using CefSharp.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserCore.Handlers
{
    public class CustomLifeSpanHandler : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return true;
        }

        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {

        }

        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {

        }

        bool ILifeSpanHandler.OnBeforePopup(IWebBrowser chromiumWebBrowser,
            IBrowser browser, IFrame frame, string targetUrl, string targetFrameName,
            WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures,
            IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            Popup?.Invoke(this, new LinkedEventArgs(targetUrl));
            newBrowser = null;
            return true;
        }

        /// <summary>
        ///     Уведомление об открытии нового сайта.
        /// </summary>
        public event EventHandler<LinkedEventArgs> Popup;

    }
}
