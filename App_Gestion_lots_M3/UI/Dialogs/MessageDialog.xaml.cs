using Microsoft.UI.Xaml.Controls;

namespace App_Gestion_lots_M3.UI.Dialogs;

// Simple informational dialog. Built as a XAML ContentDialog so it inherits the
// merged dictionaries from App.xaml (theme brushes, implicit ContentDialog style,
// theme-dictionary swaps) the same way every other dialog in this app does.
public sealed partial class MessageDialog : ContentDialog
{
    public MessageDialog(string title, string message)
    {
        InitializeComponent();
        Title = title;
        MessageText.Text = message;
    }
}
