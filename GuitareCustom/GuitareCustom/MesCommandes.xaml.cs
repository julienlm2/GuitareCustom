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
    public partial class MesCommandes : ContentPage
    {
        
        ServiceReference1.WebService1SoapClient Le_WS;
        public static string NomSession;
        public static string idSession;


        public static int? idClientConnecte;
        public static int idClientConnecteint;

        public MesCommandes()
        {
            InitializeComponent();
            Le_WS = new ServiceReference1.WebService1SoapClient(ServiceReference1.WebService1SoapClient.EndpointConfiguration.WebService1Soap12);
            NomSession = MainPage.Nom;
            idClientConnecte = Le_WS.Get_id_client_by_name(NomSession).First(); 
            if (idClientConnecte.HasValue)
                idClientConnecteint = idClientConnecte.Value;
            else
            {
                DisplayAlert("ERREUR", "ERREUR", "OK");
            }
            

            var commande = new ServiceReference1.GET_GUITARE_BY_ID_CLIENT_Result();
            var bois = new ServiceReference1.get_bois_by_id_Result();

            commande = Le_WS.Get_Guitare_By_IdClient(idClientConnecteint).FirstOrDefault();
            
            Etat_commande.Text = commande.Etat_Commande;
            id_Bois.Text = (Le_WS.Get_bois_by_id(commande.idBois).FirstOrDefault().NomBois);
            id_Bois1.Text = (Le_WS.Get_bois_by_id(commande.idBois_1).FirstOrDefault().NomBois);
            id_Bois2.Text = (Le_WS.Get_bois_by_id(commande.idBois_2).FirstOrDefault().NomBois);
            id_Micro.Text = (Le_WS.Get_micro_by_id(commande.idMicro.Value).FirstOrDefault().NomMicro);
            id_Micro1.Text = (Le_WS.Get_micro_by_id(commande.idMicro_1.Value).FirstOrDefault().NomMicro);
            id_Micro2.Text = (Le_WS.Get_micro_by_id(commande.idMicro_2).FirstOrDefault().NomMicro);
            nomVibrato.Text = commande.nomVibrato;



        }
    }
}