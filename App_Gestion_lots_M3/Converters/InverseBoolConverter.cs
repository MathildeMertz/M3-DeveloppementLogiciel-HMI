using Microsoft.UI.Xaml.Data;

namespace App_Gestion_lots_M3.Converters;

public sealed partial class InverseBoolConverter : IValueConverter
{
    public object Convert(object value, global::System.Type targetType, object parameter, string language)
    {
        return value is bool b && !b;
    }

    public object ConvertBack(object value, global::System.Type targetType, object parameter, string language)
    {
        return value is bool b && !b;
    }
}
