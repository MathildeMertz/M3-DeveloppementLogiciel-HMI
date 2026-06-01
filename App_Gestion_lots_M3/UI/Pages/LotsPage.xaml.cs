using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using App_Gestion_lots_M3.UI.Dialogs;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace App_Gestion_lots_M3.UI.Pages;

public sealed partial class LotsPage : Page
{
    // Projection directe : chaque LotTreeNode porte SOIT un Lot (parent)
    // SOIT un Evenement (feuille). Le pattern matching dans
    // treeLots_DoubleTapped résout la sélection sans détour.
    private readonly ObservableCollection<LotTreeNode> _rows = new();

    public LotsPage()
    {
        InitializeComponent();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        ChargerLots();
    }

    private void ChargerLots()
    {
        _rows.Clear();
        foreach (var lot in DAL.GetLots())
        {
            var children = new ObservableCollection<LotTreeNode>();
            foreach (var evt in DAL.GetEvenements(lot.Id_Lot))
            {
                children.Add(new LotTreeNode { Evenement = evt });
            }
            _rows.Add(new LotTreeNode { Lot = lot, Children = children });
        }
    }

    // Appelée depuis le XAML via x:Bind sur méthode statique typée. Renvoie
    // une chaîne vide quand le noeud représente un Lot (et non un Evenement),
    // ce qui laisse FallbackValue='' prendre le relais visuellement.
    public static string FormatDate(Evenement? e) =>
        e is null ? string.Empty : e.EVE_DateHeure.ToString("dd/MM/yyyy HH:mm");

    private Lot? SelectedLot()
    {
        return treeLots.SelectedItem switch
        {
            LotTreeNode { Lot: { } lot } => lot,
            _ => null,
        };
    }

    private async void btnNouveauLot_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new NouveauLotDialog { XamlRoot = XamlRoot };
        var result = await dlg.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
            ChargerLots();
            ShowStatus("Lot enregistré.", InfoBarSeverity.Success);
        }
    }

    private async void btnModifierLot_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedLot() is not Lot selectionne)
        {
            ShowStatus("Sélectionner un lot à modifier.", InfoBarSeverity.Warning);
            return;
        }
        await ModifierLotAsync(selectionne);
    }

    // Double-tap sur un Lot → édition. Les noeuds Evenement n'ont pas
    // de Lot non-null, donc SelectedLot() renvoie null et le geste est
    // ignoré naturellement.
    private async void treeLots_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
    {
        if (treeLots.SelectedItem is LotTreeNode { Lot: { } lot })
        {
            await ModifierLotAsync(lot);
        }
    }

    private async Task ModifierLotAsync(Lot lot)
    {
        var dlg = new NouveauLotDialog(lot) { XamlRoot = XamlRoot };
        var result = await dlg.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            ChargerLots();
            ShowStatus("Lot modifié.", InfoBarSeverity.Success);
        }
        else if (result == ContentDialogResult.Secondary)
        {
            var confirm = new ConfirmDialog(
                "Confirmer la suppression",
                $"Supprimer définitivement le lot {lot.LOT_Nom} ?")
            {
                XamlRoot = XamlRoot,
            };
            if (await confirm.AskAsync())
            {
                DAL.SupprimerLot(lot.LOT_Nom);
                ChargerLots();
                ShowStatus("Lot supprimé.", InfoBarSeverity.Informational);
            }
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
