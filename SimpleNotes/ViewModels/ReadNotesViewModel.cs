using System.Collections.Generic;
using GalaSoft.MvvmLight;
using SimpleNotes.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SimpleNotes.Common;
using SimpleNotes.Services;
using SimpleNotes.Views;

namespace SimpleNotes.ViewModels
{
	public class ReadNotesViewModel : ViewModelBase
	{
		private readonly INavigationService navigationService;
		private readonly IDataService dataService;
		private readonly SettingsViewModel settings;

		public ObservableCollection<Note> Notes { get; set; }
		public Note SelectedNote { get; set; }
		public bool IsNoteSelected => SelectedNote != null;

		public ReadNotesViewModel(INavigationService navigationService, IDataService dataService, SettingsViewModel settings)
		{
			this.navigationService = navigationService;
			this.dataService = dataService;;
			this.settings = settings;
		}

		public void LoadData()
		{
			var notesCollection = dataService.GetNotes().Take(settings.NumberOfShownNotes);

			notesCollection = settings.IsSortAscending
				? notesCollection.OrderBy(note => note.CreationDate)
				: notesCollection.OrderByDescending(note => note.CreationDate);

			Notes = new ObservableCollection<Note>(notesCollection);
		}

		public void EditSelectedNote()
		{
			navigationService.NavigateTo(Navigation.EditNote, SelectedNote);
		}

		public void RemoveSelectedNote()
		{
			dataService.RemoveNote(SelectedNote);
			LoadData();
		}
	}
}
