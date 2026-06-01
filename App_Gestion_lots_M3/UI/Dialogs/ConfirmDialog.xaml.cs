using Microsoft.UI.Xaml.Controls;

namespace App_Gestion_lots_M3.UI.Dialogs;

// Yes/No confirmation dialog. AskAsync wraps ShowAsync and returns bool so
// callers don't have to compare ContentDialogResult at every call site.
public sealed partial class ConfirmDialog : ContentDialog
{
    public ConfirmDialog(string title, string message)
    {
        InitializeComponent();
        Title = title;
        MessageText.Text = message;
    }

    public async Task<bool> AskAsync()
    {
        var result = await ShowAsync();
        return result == ContentDialogResult.Primary;
    }
}
