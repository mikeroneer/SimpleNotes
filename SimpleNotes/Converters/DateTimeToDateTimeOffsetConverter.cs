using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace SimpleNotes.Converters
{
	public class DateTimeToDateTimeOffsetConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if(value is DateTime)
			{
				DateTime dt = (DateTime)value;
				return new DateTimeOffset(dt);
			}
			else
			{
				return null;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			DateTimeOffset? dto = value as DateTimeOffset?;
			return dto?.DateTime;
		}
	}
}
