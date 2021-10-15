using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Plugin.Geolocator;
using System.Diagnostics;
using Xamarin.Forms.Maps;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E12272.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GPSPage : ContentPage
    {

        public GPSPage()
        {
            InitializeComponent();            
        }

        public bool Validaciones()
        {
            bool respuesta;

            if (String.IsNullOrEmpty(txtlat.Text))
            {
                respuesta = false;
            }

            else if (String.IsNullOrEmpty(txtlon.Text))
            {
                respuesta = false;
            }

            else if (String.IsNullOrEmpty(txtdireccion.Text))
            {
                respuesta = false;
            }
            else if (String.IsNullOrEmpty(txtcorta.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;

        }



        private async void btnsalvar_Clicked(object sender, EventArgs e)
        {

            if(Validaciones())
            {
                
                var GPS = new Models.gps
                {                    
                    latitud = Convert.ToInt32(this.txtlat.Text),
                    longitud = Convert.ToInt32(this.txtlon.Text),
                    direccion = this.txtdireccion.Text,
                    direcorta = this.txtcorta.Text
                };

                var resultado = await App.BaseDatos.GrabarUbicacion(GPS);
                if (resultado == 1)
                {
                    await DisplayAlert("Agregado", "Ingresado Exitosamente", "OK");
                    txtlat.Text = "";
                    txtlon.Text = "";
                    txtdireccion.Text = "";
                    txtcorta.Text = "";
                    

                }
                else
                {
                    await DisplayAlert("Error", "No se pudo guardar", "OK");
                    txtlat.Text = "";
                    txtlon.Text = "";
                    txtdireccion.Text = "";
                    txtcorta.Text = "";
                }

            }
            else
            {
                await DisplayAlert("Error", "Ingrese todos los datos", "OK");
            }

            

        }

        private void clearScreen()
        {
            this.txtlat.Text = String.Empty;
            this.txtlon.Text = String.Empty;
            this.txtdireccion.Text = String.Empty;
            this.txtcorta.Text = String.Empty;         
        }

        private async void btnsalvado_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new Views.listaUbicacion());

        }

        private async void btnMostar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.MapPage());
        }


    }
}