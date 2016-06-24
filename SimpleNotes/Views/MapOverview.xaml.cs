using System;
using System.Linq;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Messaging;
using SimpleNotes.ViewModels;

namespace SimpleNotes.Views
{
	public sealed partial class MapOverview : Page
	{
		private MapOverviewViewModel ViewModel => DataContext as MapOverviewViewModel;

		public MapOverview()
		{
			this.InitializeComponent();

			Messenger.Default.Register<string>(this, ZoomToFit);
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			ViewModel.Initialize(e.Parameter);
		}

		private void OnPushpinTapped(object sender, TappedRoutedEventArgs e)
		{
			if (!(sender is Grid)) return;

			var viewElement = (Grid) sender;
			var note = ViewModel.AllNotes.First(n => n.Id.Equals(viewElement.Tag));
			ViewModel.OnPushpinTapped(note);
		}

		private async void ZoomToFit(string message)
		{
			if (message != "zoomToFit") return;

			var box = GeoboundingBox.TryCompute(ViewModel.AllNotes.Select(n => n.GeoPoint.Position));
			await Map.TrySetViewBoundsAsync(box, new Thickness(10), MapAnimationKind.Linear);
		}
	}
}
