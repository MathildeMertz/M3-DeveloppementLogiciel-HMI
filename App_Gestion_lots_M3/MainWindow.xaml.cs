using App_Gestion_lots_M3.UI.Pages;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

namespace App_Gestion_lots_M3;

public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AppTitleBar);

        // Maximize on startup to mirror the original WinForms FormWindowState.Maximized behaviour.
        if (AppWindow.Presenter is OverlappedPresenter presenter)
        {
            presenter.Maximize();
            presenter.PreferredMinimumHeight = 420;
            presenter.PreferredMinimumWidth = 667;
        }

        NavView.SelectedItem = NavItemLots;
    }

    private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
    {
        if (args.SelectedItem is not NavigationViewItem item) return;
        var tag = item.Tag as string;
        switch (tag)
        {
            case "Lots":
                ContentFrame.Navigate(typeof(LotsPage));
                break;
            case "Recettes":
                ContentFrame.Navigate(typeof(RecettesPage));
                break;
            case "Historique":
                ContentFrame.Navigate(typeof(HistoriquePage));
                break;
            case "Statistiques":
                ContentFrame.Navigate(typeof(StatistiquesPage));
                break;
        }
    }

    private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
    {
        var canGoBack = ContentFrame.CanGoBack;
        NavView.IsBackEnabled = canGoBack;
        NavView.IsBackButtonVisible = canGoBack
            ? NavigationViewBackButtonVisible.Visible
            : NavigationViewBackButtonVisible.Collapsed;
    }

    private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
    {
        if (ContentFrame.CanGoBack) ContentFrame.GoBack();
    }
}
