using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Data;

namespace DataModel
{
    public class DataViewTrans : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ret = string.Empty;
            string a = value.ToString();
            switch (a)
            {
                case "1":
                    ret = "表";
                    break;
                case "2":
                    ret = "视图";
                    break;

            }
            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string ret = string.Empty;
            string a = value.ToString();
            switch (a)
            {
                case "表":
                    ret = "1";
                    break;
                case "视图":
                    ret = "2";
                    break;

            }
            return ret;

        }
    }


   public class DataViewColorTrans : IValueConverter
   {
       public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
           string ret = string.Empty;
           string a = value.ToString();
           switch (a)
           {
               case "1":
                   ret = "SeaGreen";
                   break;
               case "2":
                   ret = "Maroon";
                   break;


               case "视图":
                   ret = "Red";
                   break;
               case "存储过程":
                   ret = "Orange";
                   break;

               case "表":
                   ret = "Green";
                   break;

               case "函数":
                   ret = "#2b2b2b";
                   break;


           }
           return ret;

       }

       public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
       {
           string ret = string.Empty;
           string a = value.ToString();
           switch (a)
           {
               case "SeaGreen":
                   ret = "1";
                   break;
               case "Maroon":
                   ret = "2";
                   break;

               case "Red":
                   ret = "视图";
                   break;
               case "Orange":
                   ret = "存储过程";
                   break;

               case "Green":
                   ret = "表";
                   break;
               case "#2b2b2b":
                   ret = "函数";
                   break;

           }
           return ret;
       }
   }


}
