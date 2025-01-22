using CefSharp;
using CefSharp.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserCore.Handlers
{
    public class SimpleWebBrowser : IWebBrowser
    {
        public IJavascriptObjectRepository JavascriptObjectRepository => throw new NotImplementedException();

        public IDialogHandler DialogHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRequestHandler RequestHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDisplayHandler DisplayHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ILoadHandler LoadHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ILifeSpanHandler LifeSpanHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IKeyboardHandler KeyboardHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IJsDialogHandler JsDialogHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDragHandler DragHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDownloadHandler DownloadHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IContextMenuHandler MenuHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFocusHandler FocusHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IResourceRequestHandlerFactory ResourceRequestHandlerFactory { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IRenderProcessMessageHandler RenderProcessMessageHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFindHandler FindHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IAudioHandler AudioHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IFrameHandler FrameHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IPermissionHandler PermissionHandler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string TooltipText => throw new NotImplementedException();

        public bool CanExecuteJavascriptInMainFrame => throw new NotImplementedException();

        public IRequestContext RequestContext => throw new NotImplementedException();

        public bool IsBrowserInitialized => throw new NotImplementedException();

        public bool IsDisposed => throw new NotImplementedException();

        public bool IsLoading => throw new NotImplementedException();

        public bool CanGoBack => throw new NotImplementedException();

        public bool CanGoForward => throw new NotImplementedException();

        public string Address => throw new NotImplementedException();

        public IBrowser BrowserCore => throw new NotImplementedException();

        public event EventHandler<JavascriptMessageReceivedEventArgs> JavascriptMessageReceived;
        public event EventHandler<ConsoleMessageEventArgs> ConsoleMessage;
        public event EventHandler<StatusMessageEventArgs> StatusMessage;
        public event EventHandler<FrameLoadStartEventArgs> FrameLoadStart;
        public event EventHandler<FrameLoadEndEventArgs> FrameLoadEnd;
        public event EventHandler<LoadErrorEventArgs> LoadError;
        public event EventHandler<LoadingStateChangedEventArgs> LoadingStateChanged;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Focus()
        {
            throw new NotImplementedException();
        }

        public IBrowser GetBrowser()
        {
            throw new NotImplementedException();
        }

        public Task<DomRect> GetContentSizeAsync()
        {
            throw new NotImplementedException();
        }

        public void Load(string url)
        {
            throw new NotImplementedException();
        }

        public void LoadUrl(string url)
        {
            throw new NotImplementedException();
        }

        public Task<LoadUrlAsyncResponse> LoadUrlAsync(string url)
        {
            throw new NotImplementedException();
        }

        public bool TryGetBrowserCoreById(int browserId, out IBrowser browser)
        {
            throw new NotImplementedException();
        }

        public Task<LoadUrlAsyncResponse> WaitForInitialLoadAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WaitForNavigationAsyncResponse> WaitForNavigationAsync(TimeSpan? timeout = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
