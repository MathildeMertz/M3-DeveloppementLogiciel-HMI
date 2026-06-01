using Microsoft.UI.Xaml.Data;

namespace App_Gestion_lots_M3.Converters;

public sealed partial class DateTimeFormatConverter : IValueConverter
{
    public object Convert(object value, global::System.Type targetType, object parameter, string language)
    {
        if (value is not DateTime dt) return string.Empty;
        var format = parameter as string ?? "dd/MM/yyyy HH:mm";
        return dt.ToString(format);
    }

    public object ConvertBack(object value, global::System.Type targetType, object parameter, string language)
    {
        if (value is string s && DateTime.TryParse(s, out var dt)) return dt;
        return DateTime.MinValue;
    }
}
