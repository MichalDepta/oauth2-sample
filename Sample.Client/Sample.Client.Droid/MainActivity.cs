using System;
using Android.App;
using Android.OS;
using Android.Webkit;
using Newtonsoft.Json;
using Refit;
using Sample.Constants;
using Debug = System.Diagnostics.Debug;

namespace Sample.Client.Droid
{
    [Activity(Label = "Sample.Client.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private static readonly string AuthUrl =
            $"{SharedConstants.AuthorizationEndpoint}?client_id={SharedConstants.MobileClientId}&redirect_uri={Uri.EscapeDataString(SharedConstants.MobileRedirectUri)}&response_type=token&scope={SharedConstants.FooScope}";

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            WebView webView = FindViewById<WebView>(Resource.Id.webView);

            try
            {
                var service = RestService.For<IAuthorizationService>(SharedConstants.TokenEndpoint);
                var token = await service.Authorize(new UserCredentials("Michal", "password"));

                Debug.WriteLine(token);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private class MyWebViewClient : WebViewClient
        {
            private readonly Action<string> _onTokenReceived;

            public MyWebViewClient(Action<string> onTokenReceived)
            {
                _onTokenReceived = onTokenReceived;
            }

            public override bool ShouldOverrideUrlLoading(WebView view, string url)
            {
                var uri = Android.Net.Uri.Parse(url);
                if (uri.Host == "mdepta.com")
                {
                    var start = uri.Fragment.IndexOf("=", StringComparison.Ordinal);
                    var end = uri.Fragment.IndexOf("&", StringComparison.Ordinal) - 1;
                    var token = uri.Fragment.Substring(start + 1, end - start);
                    _onTokenReceived(token);
                }
                else
                {
                    view.LoadUrl(url);
                }

                return true;
            }
        }

        private class AuthResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }
        }
    }
}