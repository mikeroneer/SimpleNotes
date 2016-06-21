using System;
using GalaSoft.MvvmLight;
using SimpleNotes.Models;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Views;
using SimpleNotes.Common;
using SimpleNotes.Services;

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
		public bool IsNotesEmpty => Notes?.Count == 0;

		public string SearchText { get; set; } = string.Empty;

		public DateTime? SearchTimePeriodStart { get; set; }

		public DateTime? SearchTimePeriodEnd { get; set; }

		public bool IsSearchEnabled { get; set; }

		public ReadNotesViewModel(INavigationService navigationService, IDataService dataService, SettingsViewModel settings)
		{
			this.navigationService = navigationService;
			this.dataService = dataService;;
			this.settings = settings;

			PropertyChanged += (sender, args) =>
				{
					if (args.PropertyName == nameof(SearchText) ||
					    args.PropertyName == nameof(SearchTimePeriodStart) ||
					    args.PropertyName == nameof(SearchTimePeriodEnd))
					{
						LoadData();
					}
				};
		}

		public async void LoadData()
		{
			var notesCollection = await dataService.GetNotes();

			notesCollection = settings.IsSortAscending
				? notesCollection.OrderBy(note => note.CreationDate)
				: notesCollection.OrderByDescending(note => note.CreationDate);

			notesCollection = notesCollection.Where(note => (!SearchTimePeriodStart.HasValue || note.CreationDate >= SearchTimePeriodStart)
												&& (!SearchTimePeriodEnd.HasValue || note.CreationDate <= SearchTimePeriodEnd.Value.Date.AddDays(1))
												&& (string.IsNullOrEmpty(SearchText) || note.Text.ToLower().Contains(SearchText.ToLower()))
				).Take(settings.NumberOfShownNotes);

			Notes = new ObservableCollection<Note>(notesCollection);
		}

		public void EditSelectedNote()
		{
			navigationService.NavigateTo(Navigation.NoteDetails, SelectedNote);
		}

		public void RemoveSelectedNote()
		{
			dataService.RemoveNote(SelectedNote);
			LoadData();
		}

		public void ToggleEnableSearch()
		{
			IsSearchEnabled = !IsSearchEnabled;
		}
	}
}
