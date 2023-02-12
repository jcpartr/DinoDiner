using System;
using System.Globalization;
using System.Windows.Data;

namespace DinoDiner.PointOfSale.MenuControls
{
    /// <summary>
    /// Class to convert a RadioButton's isChecked boolean to a enum value
    /// </summary>
    /// <remarks>
    /// The isChecked property should look as follows:
    /// IsChecked="{Binding Path={BoundProperty}, Converter={StaticResource RadioButtonEnumConverter}, ConverterParameter='{EnumValue}'}"
    /// Replace {BoundProperty} with the exact name of the Binding property
    /// Replace {EnumValue} with the exact name of the Enumerator's value
    /// </remarks>
    public class RadioButtonEnumConverter : IValueConverter
    {
        /// <summary>
        /// Converts from the enum to radio buton bool
        /// </summary>
        /// <param name="value">Enum of item</param>
        /// <param name="targetType">IsChecked Boolean</param>
        /// <param name="parameter">String of the Enum value name</param>
        /// <param name="culture">Unused</param>
        /// <returns>Boolean </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value is Enum e)
            {
                if (e.ToString() == parameter.ToString())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Converts from the radio button bool to enum
        /// </summary>
        /// <param name="value">Bool value of the IsChecked Property</param>
        /// <param name="targetType">The Enum type being converted to</param>
        /// <param name="parameter">String of the Enum value name </param>
        /// <param name="culture">Unused</param>
        /// <returns>Enum Value or Nothing</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Enum.Parse(targetType, (string)parameter);
            }
            return Binding.DoNothing;
        }
    }
}
