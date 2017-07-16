using System;
using Windows.UI.Xaml.Data;

namespace XamarinFormsTabsDemo.UWP
{
	public class PageIconConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			switch (value)
			{
				case Xamarin.Forms.FileImageSource fis:
					return fis.File;
				default:
					return null;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
