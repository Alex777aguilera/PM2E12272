using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using PM2E12272.Controller;

namespace PM2E12272
{
    public partial class App : Application
    {

        static DataBaseSQLite basedatos;

        public static DataBaseSQLite BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new DataBaseSQLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM2E12272.db3"));
                }

                return basedatos;

            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
