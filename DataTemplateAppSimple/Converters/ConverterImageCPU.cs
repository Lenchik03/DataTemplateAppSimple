using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DataTemplateAppSimple.Converters
{
    internal class ConverterImageCPU : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] img = null;
            decimal val = decimal.Parse(value.ToString());
            //return Properties.Resources.Милк;
            if (val < 1000)
            {
                img = File.ReadAllBytes("1.jpg");
            }
            else if (val >= 1000)
            {
                img = File.ReadAllBytes("2.jpg");
            }
           
            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
