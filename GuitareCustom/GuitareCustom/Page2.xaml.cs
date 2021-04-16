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
    public partial class Page2 : ContentPage
    {
        ServiceReference1.WebService1SoapClient Le_WS;

        public static string NomSession;
        public static string idSession;

        public static string NomBois_1;
        public static string NomBois_2;
        public static string NomBois_3;

        public Page2()
        {
            InitializeComponent();
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
            NomSession = MainPage.Nom;
            idSession = Le_WS.Get_id_client_by_name(NomSession).ToString();

            lbl_nom_session.Text = $"Commande de {NomSession}";

            var template = new DataTemplate(typeof(TextCell));
            template.SetValue(TextCell.TextColorProperty, Color.White);
            template.SetBinding(TextCell.TextProperty, "NomBois");

            LST_Bois1.ItemTemplate = template;
            LST_Bois2.ItemTemplate = template;
            LST_Bois3.ItemTemplate = template;

            LST_Bois1.ItemsSource = Le_WS.Get_Bois();
            LST_Bois2.ItemsSource = Le_WS.Get_Bois();
            LST_Bois3.ItemsSource = Le_WS.Get_Bois();

            var image = new Image { Source = "manche.jpg" };

            var image1 = new Image { Source = "touche.jpg" };

            var image2 = new Image { Source = "corps.jpg" };
        }

        private void LST_Bois1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
            var Bois1 = (ServiceReference1.Get_Bois_Result)e.SelectedItem;
            DisplayAlert("Nom du bois selectionné", Bois1.NomBois, "OK");
            NomBois_1 = Bois1.NomBois;
        }

        private void LST_Bois2_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
            var Bois2 = (ServiceReference1.Get_Bois_Result)e.SelectedItem;
            DisplayAlert("Nom du bois selectionné", Bois2.NomBois, "OK");
            NomBois_2 = Bois2.NomBois;
        }

        private void LST_Bois3_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
            var Bois3 = (ServiceReference1.Get_Bois_Result)e.SelectedItem;
            DisplayAlert("Nom du bois selectionné", Bois3.NomBois, "OK");
            NomBois_3 = Bois3.NomBois;

        }

        private async void BTN_enregistrerBois_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Vibrato());
        }
    }
}