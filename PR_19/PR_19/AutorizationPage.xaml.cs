using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PR_19
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AutorizationPage : ContentPage
    {
        private string name;
        private string password;

        public AutorizationPage()
        {
            InitializeComponent();
        }


        async void GetClient(string name, string password)
        {
            var registration = new RegistrationParametres { Name = name, Password = password };
            string json = JsonConvert.SerializeObject(registration);
            HttpContent content = new StringContent(json);


            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://lab20.somee.com/api/Users/Registration");

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                json = await responseContent.ReadAsStringAsync();

            }


        }


        void OnButtonClicked(object sender, EventArgs e)
        {
            if (entryLogin.Text != "" && entryPassword.Text != "")
            {

                GetClient(name, password);
            }
        }

        void OnButtonReturn(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
    }
}