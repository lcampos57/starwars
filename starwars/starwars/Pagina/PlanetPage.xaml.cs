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
    public partial class PlanetPage : ContentPage
    {
        public ObservableCollection<Planets> Planet { get; set; }
        private HttpClient _client;

        private const string PlanetsDataUrl = "http://swapi.co/api/planets";

        public PlanetPage()
        {
            InitializeComponent();
            Planet = new ObservableCollection<Planets>();
            GetAllCharacters();
        }

        public async Task GetAllCharacters()
        {
            try
            {
                _client = new HttpClient();
                var response = await _client.GetStringAsync(PlanetsDataUrl);

                if (!string.IsNullOrEmpty(response))
                {
                    var data = JsonConvert.DeserializeObject<RootObjectPlanet>(response);
                    foreach (var planet in data.Planets)
                    {
                        Planet.Add(planet);
                    }

                    PlanetsListView.ItemsSource = Planet;
                }
            }
            catch (Exception)
            {
                //DisplayAlert("Error", "Something went wrong", "Ok");
            }
        }
    }
}
