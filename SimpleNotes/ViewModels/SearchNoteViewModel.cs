using GalaSoft.MvvmLight;
using SimpleNotes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotes.ViewModels
{
	class SearchNoteViewModel : ViewModelBase
	{
		public ObservableCollection<Note> SearchResults { get; set; }

		private string searchText;
		public string SearchText
		{
			get { return searchText; }
			set
			{
				searchText = value;
				Search();
			}
		}

		private DateTime searchTimePeriodStart;
		public DateTime SearchTimePeriodStart
		{
			get { return searchTimePeriodStart; }
			set
			{
				searchTimePeriodStart = value;
				Search();
			}
		}

		private DateTime searchTimePeriodEnd;
		public DateTime SearchTimePeriodEnd
		{
			get { return searchTimePeriodEnd; }
			set
			{
				searchTimePeriodEnd = value;
				Search();
			}
		}

		public SearchNoteViewModel()
		{
			SearchText = string.Empty;
		}

		private void Search()
		{
			/*SearchResults = new ObservableCollection<Note>(Global.Notes.Where(note => 
					note.Text.ToLower().Contains(SearchText.ToLower()) && 
					note.CreationDate >= SearchTimePeriodStart && 
					note.CreationDate <= searchTimePeriodEnd
				));*/
		}
	}
}
