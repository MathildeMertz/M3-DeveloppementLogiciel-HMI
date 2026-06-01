using App_Gestion_lots_M3.AccesDonnees;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace App_Gestion_lots_M3.UI.Pages;

public sealed partial class StatistiquesPage : Page
{
    public StatistiquesPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        Recalculer();
    }

    private void Recalculer()
    {
        var lots = DAL.GetLots();
        // Optional date filter — DAL doesn't store start dates yet, fall back to creation date.
        if (dtpDu?.Date is { } du)
            lots = lots.Where(l => l.LOT_DateHeureCreation.Date >= du.Date).ToList();
        if (dtpAu?.Date is { } au)
            lots = lots.Where(l => l.LOT_DateHeureCreation.Date <= au.Date).ToList();

        int enAttente = 0, enProd = 0, termines = 0, erreur = 0;
        foreach (var l in lots)
        {
            switch (l.ETA_Libelle)
            {
                case "En attente": enAttente++; break;
                case "En production": enProd++; break;
                case "Terminé": termines++; break;
                case "En erreur": erreur++; break;
            }
        }
        lblTotal.Text = lots.Count.ToString();
        lblEnAttente.Text = enAttente.ToString();
        lblEnProduction.Text = enProd.ToString();
        lblTermines.Text = termines.ToString();
        lblEnErreur.Text = erreur.ToString();
    }

    private void btnActualiser_Click(object sender, RoutedEventArgs e)
    {
        Recalculer();
    }
}
