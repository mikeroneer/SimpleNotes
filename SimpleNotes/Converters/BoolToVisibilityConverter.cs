using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace SimpleNotes.Converters
{
	public class BoolToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is bool)
			{
				if ((bool) value)
				{
					return Visibility.Visible;
				}
			}

			return Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
