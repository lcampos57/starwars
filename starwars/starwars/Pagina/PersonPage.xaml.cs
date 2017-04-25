using System;
using System.Collections.Generic;
using System.Linq;
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

namespace starwars.Pagina
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonPage : ContentPage
    {
        //public ObservableCollection<Person> Persons { get; set; }
        //private HttpClient _client;

        private string _PersonDataUrl;
        public string PersonDataUrl
        {
            get { return _PersonDataUrl; }
            set
            {
                _PersonDataUrl = value;
            }
        }

        public PersonPage(string DataPeople)
        {
            InitializeComponent();

            PersonDataUrl = DataPeople;
            //Persons = new ObservableCollection<Person>();
            GetAllCharacters();
        }

        public async Task GetAllCharacters()
        {
            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(PersonDataUrl);
                // Add an Accept header for JSON format.  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // List all Names.  
                HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call!  
                                                                            //if (response.IsSuccessStatusCode)
                                                                            //{
                var respuesta = response.Content.ReadAsStringAsync().Result;

                if (!string.IsNullOrEmpty(respuesta))
                {
                    var data = JsonConvert.DeserializeObject<RootObjectPerson>(respuesta);
                    //foreach (var person in data.Persons)
                    //{
                    //    Persons.Add(person);
                    //}

                    //PeopleListView.ItemsSource = Persons;

                }




                //_client = new HttpClient();
                //var response = await _client.GetStringAsync(PersonDataUrl);

                //if (!string.IsNullOrEmpty(response))
                //{
                //    var data = JsonConvert.DeserializeObject<RootObjectPerson>(response);
                //    foreach (var person in data.Person)
                //    {
                //        Persons.Add(person);
                //    }

                //    PeopleListView.ItemsSource = Persons;
                //}


            }
            catch (Exception)
            {
                //DisplayAlert("Error", "Something went wrong", "Ok");
            }
        }
    }
}
