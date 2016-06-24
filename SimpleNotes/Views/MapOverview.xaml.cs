using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Views;
using SimpleNotes.Common;
using SimpleNotes.ViewModels;

namespace SimpleNotes.Views
{
	public sealed partial class MapOverview : Page
	{
		private MapOverviewViewModel ViewModel => DataContext as MapOverviewViewModel;

		public MapOverview()
		{
			this.InitializeComponent();
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
	}
}
