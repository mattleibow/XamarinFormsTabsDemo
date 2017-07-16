using System;
using Xamarin.Forms;

namespace XamarinFormsTabsDemo
{
	public class DynamicTabbedPage : TabbedPage
	{
		public static readonly BindableProperty DefaultIconProperty =
			BindableProperty.CreateAttached("DefaultIcon", typeof(FileImageSource), typeof(Page), null, propertyChanged: OnDefaultIconChanged);

		public static readonly BindableProperty SelectedIconProperty =
			BindableProperty.CreateAttached("SelectedIcon", typeof(FileImageSource), typeof(Page), null);

		private Page oldPage;

		public DynamicTabbedPage()
		{
			CurrentPageChanged += OnPageChanged;
		}

		private void OnPageChanged(object sender, EventArgs e)
		{
			if (oldPage != null)
			{
				oldPage.Icon = GetDefaultIcon(oldPage);
			}

			oldPage = CurrentPage;

			CurrentPage.Icon = GetSelectedIcon(CurrentPage);
		}

		private static void OnDefaultIconChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var page = (Page)bindable;
			if (page.Icon == null)
			{
				page.Icon = GetDefaultIcon(page);
			}
		}

		public static FileImageSource GetDefaultIcon(BindableObject view)
		{
			return (FileImageSource)view.GetValue(DefaultIconProperty);
		}

		public static void SetDefaultIcon(BindableObject view, FileImageSource value)
		{
			view.SetValue(DefaultIconProperty, value);
		}

		public static FileImageSource GetSelectedIcon(BindableObject view)
		{
			return (FileImageSource)view.GetValue(SelectedIconProperty);
		}

		public static void SetSelectedIcon(BindableObject view, FileImageSource value)
		{
			view.SetValue(SelectedIconProperty, value);
		}
	}
}
