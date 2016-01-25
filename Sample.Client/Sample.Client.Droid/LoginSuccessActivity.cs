using System.Net.Http;
using System.Net.Http.Headers;
using Android.App;
using Android.OS;
using Android.Widget;
using Sample.Constants;

namespace Sample.Client.Droid
{
    [Activity(Label = "LoginSuccessActivity")]
    public class LoginSuccessActivity : Activity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LoginSuccess);
            var textView = FindViewById<TextView>(Resource.Id.textView1);
            var token = Intent.GetStringExtra("token");

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse($"Bearer {token}");
                var response = await client.GetAsync($"{SharedConstants.ResourceServerUri}/api/foo");
                textView.Text = await response.Content.ReadAsStringAsync();
            }
        }
    }
}