using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace HrApp.Converters
{
    public class ConverterBase64ImageSource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string base64Image = (string)value;

                if (base64Image == null)
                    return null;

                string convert = base64Image.Replace("data:image/jpg;base64,", string.Empty);

                // Convert base64Image from string to byte-array
                try
                {
                    var imageBytes = System.Convert.FromBase64String(convert);

                    // Return a new ImageSource
                    return ImageSource.FromStream(() => { return new MemoryStream(imageBytes); });
                }
                catch { return base64Image; }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Not implemented as we do not convert back
            throw new NotSupportedException();
        }
    }
}
