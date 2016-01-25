using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Webkit;
using Sample.Constants;

namespace Sample.Client.Droid
{
    [Activity(Label = "Sample.Client.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private static readonly string AuthUrl =
            $"{SharedConstants.AuthorizationEndpoint}?client_id={SharedConstants.MobileClientId}&redirect_uri={Uri.EscapeDataString(SharedConstants.MobileRedirectUri)}&response_type=token&scope={SharedConstants.FooScope}";

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            WebView webView = FindViewById<WebView>(Resource.Id.webView);

            if (Intent.Data?.Host == "mdepta.com")
            {
                var token = Intent.Data.GetQueryParameter("access_token");
                webView.LoadData($"<html><body>{token}</body></html>", "text/html", null);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(Intent.DataString);

                webView.Settings.JavaScriptEnabled = true;
                webView.SetWebViewClient(new MyWebViewClient(token =>
                {
                    var intent = new Intent(this, typeof (LoginSuccessActivity));
                    intent.PutExtra("token", token);
                    StartActivity(intent);
                }));

                webView.LoadUrl(AuthUrl);
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
    }
}