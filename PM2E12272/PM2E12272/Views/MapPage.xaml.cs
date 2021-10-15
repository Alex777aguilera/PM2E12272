using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Plugin.Geolocator;
using System.Diagnostics;

namespace PM2E12272.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            Pin pin = new Pin
            {
                Label = "San Pedro Sula",
                Address = "Cerca de UTH SPS",
                Type = PinType.Place,
                Position = new Position(15.5294048, -88.0003413)
            };

            mapa.Pins.Add(pin);

            var location = await Geolocation.GetLocationAsync();

            if (location == null)
            {
                location = await Geolocation.GetLastKnownLocationAsync();
            }
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(1)));

            var localizacion = CrossGeolocator.Current;

            if (localizacion != null)
            {
                localizacion.PositionChanged += Localizacion_PositionChanged;

                if (!localizacion.IsListening)
                {
                    Debug.WriteLine("StartListeningAsync");
                    await localizacion.StartListeningAsync(TimeSpan.FromSeconds(10), 100);
                }

                var posicion = await localizacion.GetPositionAsync();
                var mapalcentro = new Position(posicion.Latitude, posicion.Longitude);

                mapa.MoveToRegion(MapSpan.FromCenterAndRadius(mapalcentro, Distance.FromMiles(1)));

                //mapa.MoveToRegion(new MapSpan(mapalcentro, 2, 2));

            }
            else
            {
                await localizacion.GetLastKnownLocationAsync();
                var posicion = await localizacion.GetPositionAsync();
                var mapalcentro = new Position(posicion.Latitude, posicion.Longitude);

                mapa.MoveToRegion(new MapSpan(mapalcentro, 2, 2));
            }

        }

        private void Localizacion_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var mapalcentro = new Position(e.Position.Latitude, e.Position.Longitude);
            mapa.MoveToRegion(new MapSpan(mapalcentro, 2, 2));
        }
    }
}