using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using App_Gestion_lots_M3.UI.Dialogs;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace App_Gestion_lots_M3.UI.Pages;

public sealed partial class RecettesPage : Page
{
    // Projection directe : chaque RecetteTreeNode porte SOIT une Recette
    // (parent) SOIT une Operation (feuille). x:Bind avec propagation null
    // gère l'affichage conditionnel sans sélecteur de template.
    private readonly ObservableCollection<RecetteTreeNode> _rows = new();

    public RecettesPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        ChargerRecettes();
    }

    private void ChargerRecettes()
    {
        _rows.Clear();
        foreach (var recette in DAL.GetRecettes())
        {
            var children = new ObservableCollection<RecetteTreeNode>();
            foreach (var op in DAL.GetOperations(recette.Id_Recette))
            {
                children.Add(new RecetteTreeNode { Operation = op });
            }
            _rows.Add(new RecetteTreeNode { Recette = recette, Children = children });
        }
    }

    // Helpers statiques pour x:Bind sur méthode typée. Tous renvoient
    // string.Empty quand l'argument est null, ce qui laisse FallbackValue=''
    // gérer le rendu côté XAML.
    public static string FormatDate(Recette? r) =>
        r is null ? string.Empty : r.REC_DateHeureCreation.ToString("dd/MM/yyyy");

    public static string NbOperations(Recette? r) =>
        r is null ? string.Empty : DAL.GetOperations(r.Id_Recette).Count.ToString();

    public static string FormatTemps(Operation? o) =>
        o is null ? string.Empty : o.OPE_TempsAttente + " s";

    public static string FormatQuittance(Operation? o) =>
        o is null ? string.Empty : (o.OPE_Quittance ? "Oui" : "Non");

    private Recette? SelectedRecette()
    {
        return treeRecettes.SelectedItem switch
        {
            RecetteTreeNode { Recette: { } r } => r,
            _ => null,
        };
    }

    private async void btnNouvelleRecette_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new NouvelleRecetteDialog { XamlRoot = XamlRoot };
        var result = await dlg.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            ChargerRecettes();
            ShowStatus("Recette enregistrée.", InfoBarSeverity.Success);
        }
    }

    private async void btnModifierRecette_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedRecette() is not Recette selectionnee)
        {
            ShowStatus("Sélectionner une recette à modifier.", InfoBarSeverity.Warning);
            return;
        }
        await ModifierRecetteAsync(selectionnee);
    }

    private async void treeRecettes_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
    {
        if (treeRecettes.SelectedItem is RecetteTreeNode { Recette: { } recette })
        {
            await ModifierRecetteAsync(recette);
        }
    }

    private async Task ModifierRecetteAsync(Recette recette)
    {
        var dlg = new NouvelleRecetteDialog(recette) { XamlRoot = XamlRoot };
        var result = await dlg.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            ChargerRecettes();
            ShowStatus("Recette modifiée.", InfoBarSeverity.Success);
        }
    }

    private void ShowStatus(string message, InfoBarSeverity severity)
    {
        StatusInfoBar.Severity = severity;
        StatusInfoBar.Title = severity switch
        {
            InfoBarSeverity.Success => "Succès",
            InfoBarSeverity.Warning => "Attention",
            InfoBarSeverity.Error => "Erreur",
            _ => "Information",
        };
        StatusInfoBar.Message = message;
        StatusInfoBar.IsOpen = true;
    }
}
