using System;
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
		public bool IsNotesEmpty { get; set; }

		private string searchText;
		public string SearchText
		{
			get { return searchText; }
			set
			{
				searchText = value;
				LoadData();
			}
		}

		private DateTime searchTimePeriodStart;

		public DateTime SearchTimePeriodStart
		{
			get { return searchTimePeriodStart; }
			set
			{
				searchTimePeriodStart = value;
				LoadData();
			}
		}

		private DateTime searchTimePeriodEnd;
		public DateTime SearchTimePeriodEnd
		{
			get { return searchTimePeriodEnd; }
			set
			{
				searchTimePeriodEnd = value;
				LoadData();
			}
		}

		public ReadNotesViewModel(INavigationService navigationService, IDataService dataService, SettingsViewModel settings)
		{
			this.navigationService = navigationService;
			this.dataService = dataService;;
			this.settings = settings;

			SearchText = String.Empty;
			SearchTimePeriodStart = DateTime.Now.AddYears(-1);
			SearchTimePeriodEnd = DateTime.Now.AddDays(1);
		}

		public void LoadData()
		{
			var notesCollection = dataService.GetNotes().Take(settings.NumberOfShownNotes);

			notesCollection = settings.IsSortAscending
				? notesCollection.OrderBy(note => note.CreationDate)
				: notesCollection.OrderByDescending(note => note.CreationDate);

			notesCollection = notesCollection.Where(note =>
					note.Text.ToLower().Contains(SearchText.ToLower()) &&
					note.CreationDate >= SearchTimePeriodStart &&
					note.CreationDate <= searchTimePeriodEnd
				);

			Notes = new ObservableCollection<Note>(notesCollection);
			IsNotesEmpty = Notes.Count == 0;
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

		public bool IsSearchEnabled { get; set; }

		public void SearchForNote()
		{
			if (IsSearchEnabled)
			{
				IsSearchEnabled = false;
			}
			else
			{
				IsSearchEnabled = true;
			}
		}
	}
}
