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
    public partial class FilmPage : ContentPage
    {
        public ObservableCollection<Films> Films { get; set; }
        private HttpClient _client;

        private const string FilmDataUrl = "http://swapi.co/api/films";

        public FilmPage()
        {
            InitializeComponent();
            Films = new ObservableCollection<Films>();
            GetAllCharacters();
        }

        public async Task GetAllCharacters()
        {
            try
            {
                _client = new HttpClient();
                var response = await _client.GetStringAsync(FilmDataUrl);

                if (!string.IsNullOrEmpty(response))
                {
                    var data = JsonConvert.DeserializeObject<RootObjectFilm>(response);
                    foreach (var film in data.Films)
                    {
                        Films.Add(film);
                    }

                    FilmListView.ItemsSource = Films;
                }
            }
            catch (Exception)
            {
                //DisplayAlert("Error", "Something went wrong", "Ok");
            }
        }

    }
}
