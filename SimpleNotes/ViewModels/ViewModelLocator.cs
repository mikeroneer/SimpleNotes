using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotes.ViewModels
{
	public class ViewModelLocator
	{

		static NewNoteViewModel newNoteViewModel;
		static ViewModelLocator()
		{
			newNoteViewModel = new NewNoteViewModel();
		}
		public NewNoteViewModel NewNoteViewModel => newNoteViewModel;
	}
}
