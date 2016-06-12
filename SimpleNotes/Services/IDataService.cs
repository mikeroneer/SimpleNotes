using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleNotes.Models;

namespace SimpleNotes.Services
{
	public interface IDataService
	{
		IEnumerable<Note> GetNotes();
		void SaveNote(Note note);
		void UpdateNote(Note note);
		void RemoveNote(Note note);
		void SetNotes(IEnumerable<Note> notes);
	}
}
