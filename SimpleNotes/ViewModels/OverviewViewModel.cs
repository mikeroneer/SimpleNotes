using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace SimpleNotes.ViewModels
{
	class OverviewViewModel : ViewModelBase
	{
		public ObservableCollection<string> MenuItems { get; set; }

		public OverviewViewModel()
		{
			MenuItems = new ObservableCollection<string> { "Create Note", "Read Notes", "Search for a Note", "Settings"};
		}
	}
}
