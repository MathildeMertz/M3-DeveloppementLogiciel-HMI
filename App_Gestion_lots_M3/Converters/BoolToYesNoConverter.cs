using Microsoft.UI.Xaml.Data;

namespace App_Gestion_lots_M3.Converters;

public sealed partial class BoolToYesNoConverter : IValueConverter
{
    public object Convert(object value, global::System.Type targetType, object parameter, string language)
    {
        return value is bool b && b ? "Oui" : "Non";
    }

    public object ConvertBack(object value, global::System.Type targetType, object parameter, string language)
    {
        return value is string s && s == "Oui";
    }
}
