using starwars.Pagina;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace starwars
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage : TabbedPage
    {
        public TabPage()
        {
            InitializeComponent();

            this.Children.Add(new FilmPage());
            this.Children.Add(new PeoplePage());
            this.Children.Add(new PlanetPage());
        }
    }
}
