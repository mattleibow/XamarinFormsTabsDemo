using System;
using Android.Support.Design.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(XamarinFormsTabsDemo.DynamicTabbedPage), typeof(XamarinFormsTabsDemo.Droid.DynamicTabbedPageRenderer))]

namespace XamarinFormsTabsDemo.Droid
{
	public class DynamicTabbedPageRenderer : TabbedPageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
		{
			base.OnElementChanged(e);

			if (Element != null)
			{
				Element.CurrentPageChanged += OnPageChanged;
			}
		}

		private void OnPageChanged(object sender, EventArgs e)
		{
			var tabs = ViewGroup.GetChildAt(1) as TabLayout;

			if (tabs == null)
				return;

			for (var i = 0; i < Element.Children.Count; i++)
			{
				var child = Element.Children[i];
				var icon = child.Icon;
				if (string.IsNullOrEmpty(icon))
					continue;

				var tab = tabs.GetTabAt(i);
				SetTabIcon(tab, icon);
			}
		}
	}
}
