using SimpleNotes.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotes
{
	class Global
	{
		private static ObservableCollection<Note> notes = new ObservableCollection<Note>();
		public static ObservableCollection<Note> Notes { get { return notes; } set { notes = value; } }
		public static int NumberOfShownNotes { get; set; } = 5;
	}
}
