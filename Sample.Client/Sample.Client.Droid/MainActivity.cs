using System;
using System.IO;
using System.Net;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Webkit;
using Newtonsoft.Json;
using Sample.Constants;

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

            //webView.Settings.JavaScriptEnabled = true;
            //webView.SetWebViewClient(new MyWebViewClient(token =>
            //{
            //    var intent = new Intent(this, typeof (LoginSuccessActivity));
            //    intent.PutExtra("token", token);
            //    StartActivity(intent);
            //}));

            //webView.LoadUrl(AuthUrl);

            var clientCredentials = "cmVzb3VyY2Vvd25lcmNsaWVudDpjbGllbnRzZWNyZXQ=";
            var request = new HttpWebRequest(new Uri(SharedConstants.TokenEndpoint))
            {
                Method = "POST",
                ContentType = "x-www-form-urlencoded"
            };

            request.Headers.Add(HttpRequestHeader.Authorization, $"Basic {clientCredentials}");

            using (var stream = request.GetRequestStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write($"grant_type=password&scope={SharedConstants.FooScope}&username=Michal&password=password");
            }

            var response = await request.GetResponseAsync();
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var x = JsonConvert.DeserializeObject<AuthResponse>(json);
                var intent = new Intent(this, typeof(LoginSuccessActivity));
                intent.PutExtra("token", x.AccessToken);
                StartActivity(intent);
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