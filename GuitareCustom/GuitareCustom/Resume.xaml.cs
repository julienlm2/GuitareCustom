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
    public partial class Resume : ContentPage
    {
        ServiceReference1.WebService1SoapClient Le_WS;

        public static string NomSession;
        public static string idSession;
        public static int? idSesionint;

        public static int? id_Micro_Neck;
        public static int? id_Micro_Bridge;
        public static int? id_Micro_Central;

        public static int? id_Bois_Manche;
        public static int? id_Bois_Touche;
        public static int? id_bois_Corps;

        public static int? id_Vibrato;

        public Resume()
        {
            InitializeComponent();
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
            NomSession = MainPage.Nom;
            idSesionint = Le_WS.Get_id_client_by_name(NomSession).First();
            
            Microneck.Text = Page1.NomMicro_1;
            Microbridge.Text = Page1.NomMicro_2;
            MicroCentral.Text = Page1.NomMicro_3;

            Manche.Text = Page2.NomBois_1;
            Touche.Text = Page2.NomBois_2;
            lbl_Corps.Text = Page2.NomBois_3;

            lbl_Vibrato.Text = Vibrato.NomVibrato;

            // CONVERSION NAME EN ID 

            id_Micro_Neck = Le_WS.Get_id_Micro_By_Name(Page1.NomMicro_1).First();
            id_Micro_Bridge = Le_WS.Get_id_Micro_By_Name(Page1.NomMicro_2).First();
            id_Micro_Central = Le_WS.Get_id_Micro_By_Name(Page1.NomMicro_3).First();

            id_Bois_Manche = Le_WS.Get_Id_Bois_By_Name(Page2.NomBois_1).First();
            id_Bois_Touche = Le_WS.Get_Id_Bois_By_Name(Page2.NomBois_2).First();
            id_bois_Corps = Le_WS.Get_Id_Bois_By_Name(Page2.NomBois_3).First();

            id_Vibrato = Le_WS.Get_id_Vibrato_by_Name(Vibrato.NomVibrato).First();

            //------------------------
        }



        private async void Button_Clicked(object sender, EventArgs e)
        {
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);

            var confirmed = await DisplayAlert("Valider la commande", "êtes-vous sûr de valider" +
                " votre commande ? ", "Oui", "Non");
            if (confirmed)
            {
                Le_WS.Add_Guitare(id_Micro_Neck, id_Micro_Bridge, id_Micro_Central, id_Bois_Manche, id_Bois_Touche, id_bois_Corps, idSesionint, id_Vibrato);
                await DisplayAlert("Validation de commande", "Votre Commande est en préparation" ,"Ok");
                await Navigation.PushAsync(new MainPage());

            }
            else
            {
                await Navigation.PushAsync(new Vibrato());
            }
        }
    }
}