using System.Collections.ObjectModel;
using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using App_Gestion_lots_M3.UI.Dialogs;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace App_Gestion_lots_M3.UI.Pages;

public sealed record EvenementRow(string Date, string Heure, string Evenement);

public sealed partial class HistoriquePage : Page
{
    private List<Lot> _lots = new();
    private readonly ObservableCollection<EvenementRow> _evenements = new();
    private bool _suppressEvents;

    public HistoriquePage()
    {
        InitializeComponent();
        grdEvenements.ItemsSource = _evenements;
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        _lots = DAL.GetLots();

        _suppressEvents = true;
        cboSelectLotTrace.ItemsSource = _lots.Select(l => l.LOT_Nom).ToList();
        _suppressEvents = false;

        // Optional incoming lot name (passed via Frame.Navigate parameter).
        if (e.Parameter is string nomLot && !string.IsNullOrEmpty(nomLot))
        {
            var idx = _lots.FindIndex(l => l.LOT_Nom == nomLot);
            if (idx >= 0) cboSelectLotTrace.SelectedIndex = idx;
        }
        else if (_lots.Count > 0)
        {
            cboSelectLotTrace.SelectedIndex = 0;
        }
    }

    private void cboSelectLotTrace_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (_suppressEvents) return;
        Rafraichir();
    }

    private void dtpDu_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args) => Rafraichir();
    private void dtpAu_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args) => Rafraichir();
    private void rbFiltreEvenement_SelectionChanged(object sender, SelectionChangedEventArgs e) => Rafraichir();

    private void Rafraichir()
    {
        _evenements.Clear();
        if (cboSelectLotTrace.SelectedIndex < 0 || cboSelectLotTrace.SelectedIndex >= _lots.Count) return;

        var lot = _lots[cboSelectLotTrace.SelectedIndex];
        IEnumerable<Evenement> evs = DAL.GetEvenements(lot.Id_Lot);

        if (dtpDu?.Date is { } du) evs = evs.Where(ev => ev.EVE_DateHeure.Date >= du.Date);
        if (dtpAu?.Date is { } au) evs = evs.Where(ev => ev.EVE_DateHeure.Date <= au.Date);

        var filtre = (rbFiltreEvenement.SelectedItem as RadioButton)?.Content as string;
        switch (filtre)
        {
            case "Début":
                evs = evs.Where(ev => ev.EVE_Message.StartsWith("Début", StringComparison.OrdinalIgnoreCase));
                break;
            case "Fin":
                evs = evs.Where(ev => ev.EVE_Message.StartsWith("Fin", StringComparison.OrdinalIgnoreCase));
                break;
            case "Alarmes":
                evs = evs.Where(ev =>
                    ev.EVE_Message.Contains("Alarme", StringComparison.OrdinalIgnoreCase) ||
                    ev.EVE_Message.Contains("Barrière", StringComparison.OrdinalIgnoreCase));
                break;
        }

        foreach (var ev in evs)
        {
            _evenements.Add(new EvenementRow(
                ev.EVE_DateHeure.ToString("dd/MM/yyyy"),
                ev.EVE_DateHeure.ToString("HH:mm:ss"),
                ev.EVE_Message));
        }
    }

    private async void btnExporterPDF_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new MessageDialog("Export PDF", "Fonctionnalité à venir.") { XamlRoot = XamlRoot };
        await dlg.ShowAsync();
    }
}
