using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E12272
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void toolbar01_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.GPSPage());
        }

        private async void toolbar02_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.listaUbicacion());
        }
    }
}
