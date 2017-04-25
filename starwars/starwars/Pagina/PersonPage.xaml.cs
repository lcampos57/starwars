using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Net.Http;
//using System.Threading.Tasks;
using Newtonsoft.Json;
using starwars.Modelo;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace starwars.Pagina
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonPage : ContentPage
    {
        ObservableCollection<Person> persons = new ObservableCollection<Person>();

        private string _PeopleSelDataUrl;
        public string PeopleSelDataUrl
        {
            get { return _PeopleSelDataUrl; }
            set
            {
                _PeopleSelDataUrl = value;
            }
        }

        public PersonPage(string DataPeople)
        {
            InitializeComponent();
            PeopleSelDataUrl = DataPeople;
            GetAllCharacters();

        }

        public async Task GetAllCharacters()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(PeopleSelDataUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!  
                                                                            //if (response.IsSuccessStatusCode)
                                                                            //{
                var respuesta = response.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrEmpty(respuesta))
                {
                    var data = JsonConvert.DeserializeObject<RootObjectPerson>(respuesta);

                    persons.Add(new Person { name = data.name.ToString() });
                    persons.Add(new Person { info = "Peso: " + data.height.ToString() });
                    persons.Add(new Person { info = "Cabello: " + data.hair_color.ToString() });
                    persons.Add(new Person { info = "Apariencia: " + data.skin_color.ToString() });
                    persons.Add(new Person { info = "Color de ojos: " + data.eye_color.ToString() });
                    persons.Add(new Person { info = "Cumpleaños: " + data.birth_year.ToString() });
                    persons.Add(new Person { info = "genero: " + data.gender.ToString() });
                    persons.Add(new Person { info = "hogar: " + data.homeworld.ToString() });

                    PersonListView.ItemsSource = persons;
                    
                }



            }
            catch (Exception)
            {
                //DisplayAlert("Error", "Something went wrong", "Ok");
            }
        }

    }
}
