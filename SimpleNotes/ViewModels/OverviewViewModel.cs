
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace SimpleNotes.ViewModels
{
	public class OverviewViewModel : ViewModelBase
	{
		private readonly INavigationService navigationService;

		public ObservableCollection<string> MenuItems { get; set; }

		public OverviewViewModel(INavigationService navigationService)
		{
			this.navigationService = navigationService;

			MenuItems = new ObservableCollection<string> { "Create Note", "Read Notes", "Search for a Note", "Settings"};
		}
	}
}
