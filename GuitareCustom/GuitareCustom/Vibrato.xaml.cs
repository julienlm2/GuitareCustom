using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GuitareCustom
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vibrato : ContentPage
    {
        ServiceReference1.WebService1SoapClient Le_WS;

        public static string NomSession;
        public static string idSession;

        public static string NomVibrato;



        public Vibrato()
        {
            InitializeComponent();
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
            NomSession = MainPage.Nom;
            idSession = Le_WS.Get_id_client_by_name(NomSession).ToString();

            lbl_nom_session.Text = $"Commande de {NomSession}";

            var template = new DataTemplate(typeof(TextCell));
            template.SetValue(TextCell.TextColorProperty, Color.White);
            template.SetBinding(TextCell.TextProperty, "nomVibrato");

            LST_Vibrato.ItemTemplate = template;

            LST_Vibrato.ItemsSource = Le_WS.Get_Vibrato();


            var image = new Image { Source = "vibrato.jpg" };
        }

        private void LST_Vibrato_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
            var Vibrato = (ServiceReference1.Get_Vibrato_Result)e.SelectedItem;
            DisplayAlert("Nom du vibrato selectionné", Vibrato.nomVibrato, "OK");
            NomVibrato = Vibrato.nomVibrato;
        }

        private async void BTN_enregistrerVibrato_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Resume());
        }
    }
}