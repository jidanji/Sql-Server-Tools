using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace DataModel
{
    public class DataTypeReadOnly : IValueConverter
    {

        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? ret = true;
            ret = (value.ToString() == "1");
            return ret;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool a = (bool)value;
            if (a)
            {
                return "2";
            }
            else
            {
                return "1";
            }
        }
    }
}
