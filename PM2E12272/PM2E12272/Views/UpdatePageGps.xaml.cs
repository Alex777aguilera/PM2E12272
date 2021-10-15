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
    public partial class UpdatePageGps : ContentPage
    {
        public UpdatePageGps()
        {
            InitializeComponent();
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            var GPS = new Models.gps
            {
                codigo = Convert.ToInt32(this.txtid.Text),
                latitud = Convert.ToInt32(this.txtlat.Text),
                longitud = Convert.ToInt32(this.txtlon.Text),
                direccion = this.txtdireccion.Text,
                direcorta = this.txtcorta.Text
            };

            if (await App.BaseDatos.GrabarUbicacion(GPS) > 0) 
            {
                await DisplayAlert("Dato Actualizado", "Dato a sido actualizado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Dato no actualizado", "OK");
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {

            var GPS = new Models.gps
            {
                codigo = Convert.ToInt32(this.txtid.Text),
                latitud = Convert.ToInt32(this.txtlat.Text),
                longitud = Convert.ToInt32(this.txtlon.Text),
                direccion = this.txtdireccion.Text,
                direcorta = this.txtcorta.Text
            };

            if (await App.BaseDatos.EliminarUbicacion(GPS) > 0)
            {
                await DisplayAlert("Dato Eliminado", "Dato a sido eliminado correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Dato no eliminado", "OK");
            }

        }
    }
}