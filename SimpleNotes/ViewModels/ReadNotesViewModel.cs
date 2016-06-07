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
	class ReadNotesViewModel : ViewModelBase
	{
		public ObservableCollection<Note> Notes { get; set; }

		public ReadNotesViewModel()
		{
			Notes = new ObservableCollection<Note>(Global.Notes.OrderByDescending(note => note.CreationDate).Take(Global.NumberOfShownNotes).ToList());
		}
	}
}
