using Microsoft.UI.Xaml;

namespace App_Gestion_lots_M3;

public partial class App : Application
{
    public static MainWindow MainWindow { get; private set; }

    public App()
    {
        InitializeComponent();
    }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        MainWindow = new MainWindow();
        MainWindow.Activate();
    }
}
