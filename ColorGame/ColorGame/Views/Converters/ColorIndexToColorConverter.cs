using ColorGame.DTOs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ColorGame.Views
{
    public class ColorIndexToColorConverter : IValueConverter
    {
        public Color Color { set; get; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var colorIndex = (ColorIndex)value;

            return Color = GetColor(colorIndex);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return -1; 
        }

        public Color GetColor(ColorIndex index)
        {
            switch (index)
            {
                case ColorIndex.Red: return Color.Red; 
                case ColorIndex.Yellow: return Color.Yellow;
                case ColorIndex.Blue: return Color.Blue;
                default: return Color.Green;
            }
        }

    }
}
