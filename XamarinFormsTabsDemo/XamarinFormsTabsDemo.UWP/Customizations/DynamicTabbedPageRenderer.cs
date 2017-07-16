using Windows.UI.Xaml;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(XamarinFormsTabsDemo.DynamicTabbedPage), typeof(XamarinFormsTabsDemo.UWP.DynamicTabbedPageRenderer))]

namespace XamarinFormsTabsDemo.UWP
{
	public class DynamicTabbedPageRenderer : TabbedPageRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

			// override the default control style with ours
			if (Control != null)
			{
				Control.Style = (Style)Application.Current.Resources["DynamicTabbedPageStyle"];
			}
		}
	}
}
