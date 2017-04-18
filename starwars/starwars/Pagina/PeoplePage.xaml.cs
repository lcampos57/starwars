using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Net.Http;
//using System.Threading.Tasks;
using Newtonsoft.Json;
using starwars.Modelo;

namespace starwars
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonPage : ContentPage
    {
        public ObservableCollection<People> Peoples { get; set; }
        private HttpClient _client;

        private const string PeopleDataUrl = "http://swapi.co/api/people";

        public PersonPage()
        {
            InitializeComponent();
            Peoples = new ObservableCollection<People>();
            GetAllCharacters();
        }

        public async Task GetAllCharacters()
        {
            try
            {
                _client = new HttpClient();
                var response = await _client.GetStringAsync(PeopleDataUrl);

                if (!string.IsNullOrEmpty(response))
                {
                    var data = JsonConvert.DeserializeObject<RootObject>(response);
                    foreach (var people in data.Peoples)
                    {
                        Peoples.Add(people);
                    }

                    PeopleListView.ItemsSource = Peoples;
                }
            }
            catch (Exception)
            {
                //DisplayAlert("Error", "Something went wrong", "Ok");
            }
        }
    }
}
