
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using starwars.Pagina;

namespace starwars
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage : TabbedPage
    {
        public TabPage()
        {
            this.Children.Add(new FilmPage());
            this.Children.Add(new PeoplePage());
            this.Children.Add(new PlanetPage());
        }
    }
}
