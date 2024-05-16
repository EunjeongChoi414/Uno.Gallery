using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Linq;
using Uno.Gallery.Views.NestedPages;

namespace Uno.Gallery.Views.Samples
{
	[SamplePage(SampleCategory.UIComponents, "NavigationView", Description = "This control is used for application navigation from a menu.", DocumentationLink = "https://learn.microsoft.com/en-us/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.controls.navigationview")]
	public sealed partial class NavigationViewSamplePage : Page
	{
		private NavigationView _defaultNav;
		private NavigationView _topNav;

		public NavigationViewSamplePage()
		{
			InitializeComponent();
			Loaded += OnLoaded;
		}

		private void OnLoaded(object sender, RoutedEventArgs e)
		{
			_defaultNav = SamplePageLayout.GetSampleChild<NavigationView>(Design.Material, "DefaultNav");
			_defaultNav.SelectedItem = _defaultNav.MenuItems.OfType<NavigationViewItem>().First();

			_topNav = SamplePageLayout.GetSampleChild<NavigationView>(Design.Material, "TopNav");
			_topNav.SelectedItem = _defaultNav.MenuItems.OfType<NavigationViewItem>().First();
		}

		private void DefaultNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
		{
			Frame frame = (Frame)sender.FindName("DefaultNav_ContentFrame");
			if (args.IsSettingsSelected)
			{
				frame.Navigate(typeof(NavigationViewSample_SettingsPage));
			}
			else
			{
				var selectedItem = (NavigationViewItem)args.SelectedItem;
				string pageName = (string)selectedItem.Tag;
				sender.Header = "Sample Page " + pageName[^1..];
				var pagePath = "Uno.Gallery.Views.NestedPages." + pageName;
				frame.Navigate(Type.GetType(pagePath));
			}
		}

		private void TopNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
		{
			Frame frame = (Frame)sender.FindName("TopNav_ContentFrame");
			if (args.IsSettingsSelected)
			{
				frame.Navigate(typeof(NavigationViewSample_SettingsPage));
			}
			else
			{
				var selectedItem = (NavigationViewItem)args.SelectedItem;
				string pageName = (string)selectedItem.Tag;
				sender.Header = "Sample Page " + pageName[^1..];
				var pagePath = "Uno.Gallery.Views.NestedPages." + pageName;
				frame.Navigate(Type.GetType(pagePath));
			}
		}
	}
}
