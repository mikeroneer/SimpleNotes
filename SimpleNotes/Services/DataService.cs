using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleNotes.Models;

namespace SimpleNotes.Services
{
	public class DataService : IDataService
	{
		private List<Note> notes;

		public DataService()
		{
			notes = new List<Note>();
		}

		public IEnumerable<Note> GetNotes()
		{
			return notes;
		}

		public void SetNotes(IEnumerable<Note> notesToSet)
		{
			if (notesToSet != null)
			{
				notes = new List<Note>(notesToSet);
			}
			else
			{
				notes = new List<Note>();
			}
		}

		public void SaveNote(Note note)
		{
			notes.Add(note);
		}

		public void UpdateNote(Note updatedNote)
		{
			int index = notes.IndexOf(updatedNote);
			notes[index].Text = updatedNote.Text;
		}

		public void RemoveNote(Note note)
		{
			notes.Remove(note);
		}
	}
}
