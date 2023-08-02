using AltV.Net.Client.Elements.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AltV.Net.Client;
using AltV.Net;

namespace Client
{
    internal class Web : IScript
    {
        private static IWebView? _webView;

        public static void CreateWebView()
        {
            Alt.LogError($"Web");
            WebViewObj = Alt.CreateWebView("http://resource/client/WebView/index.html");
        }
        
        
        public static IWebView WebViewObj
        {
#pragma warning disable CS8603 // Possible null reference return.
            get { return _webView; }
#pragma warning restore CS8603 // Possible null reference return.
            set { _webView = value; }
        }
    }
}
