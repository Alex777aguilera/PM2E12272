using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E12272.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class listaUbicacion : ContentPage
    {
        public listaUbicacion()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var listaGPS = await App.BaseDatos.ObtenerListaGPS();
            lsGPS.ItemsSource = listaGPS;
        }

        private async void lsGPS_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            Models.gps item = (Models.gps)e.Item;
            //await DisplayAlert("Elemento tocado", "Codigo :" + item.codigo , "OK");

            var page = new Views.UpdatePageGps();
            page.BindingContext = item;
            await Navigation.PushAsync(page);

        }
    }
}