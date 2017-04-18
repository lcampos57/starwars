
using Xamarin.Forms;

namespace starwars
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new starwars.MainPage();

            //// tabbed page 
            //var tabContainer = new TabbedPage();
            //tabContainer.Children.Add(new ContentPage() { Title = "Films" });
            //tabContainer.Children.Add(new ContentPage() { Title = "Personaje" });
            //tabContainer.Children.Add(new ContentPage() { Title = "Planetas" });

            //// The root page of your application
            //MainPage = tabContainer;

            MainPage = new starwars.PlanetPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
