using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuitareCustom
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage())
            {BarBackgroundColor = Color.Black,
            Title = "GuitareCustom",
            BarTextColor = Color.White
            };
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
