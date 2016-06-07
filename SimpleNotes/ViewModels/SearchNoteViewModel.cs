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
			get
			{
				return searchText;
			}
			set
			{
				searchText = value;
				Search(searchText);
			}
		}

		private DateTime searchTimePeriodStart;

		public DateTime SearchTimePeriodStart
		{
			get
			{
				return searchTimePeriodStart;
			}
			set
			{
				searchTimePeriodStart = value;
			}
		}

		private DateTime searchTimePeriodEnd;

		public DateTime SearchTimePeriodEnd
		{
			get
			{
				return searchTimePeriodEnd;
			}
			set
			{
				searchTimePeriodEnd = value;
			}
		}

		public SearchNoteViewModel()
		{
			SearchResults = new ObservableCollection<Note>();
		}

		private void Search(string searchValue)
		{
			SearchResults.Clear();

			foreach(Note note in Global.Notes)
			{
				if(note.Text.ToLower().Contains(searchValue.ToLower()))
				{
					SearchResults.Add(note);
				}
			}
		}
	}
}
