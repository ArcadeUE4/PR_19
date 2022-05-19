using System;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace PR_19
{
    public partial class MainPage : ContentPage
    {
        private string name;
        private string password;



        public MainPage()
        {
            InitializeComponent();
        }


        async void GetClient()
        {
            var registration = new RegistrationParametres { Name = name, Password = password };
            string json = JsonConvert.SerializeObject(registration);
            HttpContent content = new StringContent(json);


            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://lab20.somee.com/api/Users/Autorization");

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                HttpContent responseContent = response.Content;
                json = await responseContent.ReadAsStringAsync();

            }


        }


        void OnButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AutorizationPage());
        }

        void OnButtonReturn(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }

    }
}
