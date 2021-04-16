using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuitareCustom
{
    public partial class MainPage : ContentPage
    {

        ServiceReference1.WebService1SoapClient Le_WS;
        public static String Nom;


        public MainPage()
        {
            InitializeComponent();
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
           Time.Text = Le_WS.get_time();
            BTN_Connecter.IsVisible = false;
            TBX_MAIL.IsVisible = false;
            TBX_TEL.IsVisible = false;
            TBX_CONNECTER.Text = "Se Connecter";
        }

            private async void BTN_ENREGISTRER_Clicked(object sender, EventArgs e)
            {

            String Mail;
            String Telephone;

            Nom = TBX_NOM.Text;
            Mail = TBX_MAIL.Text;
            Telephone = TBX_TEL.Text;

            if (Nom != null)
            {
                Le_WS.add_client(Nom, Mail, Telephone);
            await Navigation.PushAsync(new Page1());
            }else{await DisplayAlert("Attention", "Le champ Nom est obligatoire", "Ok");}
               
            if(Nom != null)
            {
                BTN_Connecter.IsVisible = true;
            }
            }

        private async void BTN_Connecter_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }

        private void BTN_CREER_COMPTE_Clicked(object sender, EventArgs e)
        {
            TBX_MAIL.IsVisible = true;
            TBX_TEL.IsVisible = true;
            BTN_CREER_COMPTE.IsVisible = false;
            TBX_CONNECTER.Text = "S'Enregistrer";
        }
    }
}
