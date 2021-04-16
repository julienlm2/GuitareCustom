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
    public partial class Page1 : ContentPage
    {

       ServiceReference1.WebService1SoapClient Le_WS;

        public static string NomSession;
        public static string idSession;

        public static int? idClientConnecte;
        public static int idClientConnecteint;

        public static string NomMicro_1;
        public static string NomMicro_2;
        public static string NomMicro_3;

        public Page1()
        {
            InitializeComponent();
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
            NomSession = MainPage.Nom;
            idClientConnecte = Le_WS.Get_id_client_by_name(NomSession).First();

            lbl_nom_session.Text = $"Commande de {NomSession}";

            var template = new DataTemplate(typeof(TextCell));
            template.SetValue(TextCell.TextColorProperty, Color.White);
            template.SetBinding(TextCell.TextProperty, "NomMicro");
            
            LST_Micro1.ItemTemplate = template;
            LST_Micro2.ItemTemplate = template;
            LST_Micro3.ItemTemplate = template;

            LST_Micro1.ItemsSource = Le_WS.Get_Micro();
            LST_Micro2.ItemsSource = Le_WS.Get_Micro();
            LST_Micro3.ItemsSource = Le_WS.Get_Micro();

            var image = new Image { Source = "neck.jpg" };

            var image1 = new Image { Source = "bridge.jpg" };

            var image2 = new Image { Source = "central.jpg" };

            BTN_COMMANDE.IsVisible = false;

            if (idClientConnecte.HasValue)
                idClientConnecteint = idClientConnecte.Value;
            else
            {
                DisplayAlert("ERREUR", "ERREUR", "OK");
            }

            var valid = new ServiceReference1.GET_GUITARE_BY_ID_CLIENT_Result();
            
                valid = Le_WS.Get_Guitare_By_IdClient(idClientConnecteint).FirstOrDefault();

            if (valid != null){
                DisplayAlert("Attention !", "Vous avez deja une ou plusieurs commandes", "Ok");
                BTN_COMMANDE.IsVisible = true;
            }
            
            
        }

        private void LST_Micro1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
            var Micro1 = (ServiceReference1.Get_Micro_Result)e.SelectedItem;
            DisplayAlert("Nom du micro selectionné", Micro1.NomMicro, "OK");
            NomMicro_1 = Micro1.NomMicro;
        }

        private void LST_Micro2_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
            var Micro2 = (ServiceReference1.Get_Micro_Result)e.SelectedItem;
            DisplayAlert("Nom du micro selectionné", Micro2.NomMicro, "OK");
            NomMicro_2 = Micro2.NomMicro;
        }
        private void LST_Micro3_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
            var Micro3 = (ServiceReference1.Get_Micro_Result)e.SelectedItem;
            DisplayAlert("Nom du micro selectionné", Micro3.NomMicro, "OK");
            NomMicro_3 = Micro3.NomMicro;
        }

        private async void BTN_enregistrermicro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2());
        }

        private async void BTN_COMMANDE_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MesCommandes());
        }
    }
}