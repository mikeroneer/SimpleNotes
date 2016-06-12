
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace SimpleNotes.ViewModels
{
	public class OverviewViewModel : ViewModelBase
	{
		public ObservableCollection<string> MenuItems { get; set; }

		public OverviewViewModel()
		{
			MenuItems = new ObservableCollection<string> { "Create Note", "Read Notes", "Settings"};
		}
	}
}
