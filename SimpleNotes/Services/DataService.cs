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
			notes = new List<Note>(notesToSet);
		}

		public void SaveNote(Note note)
		{
			notes.Add(note);
		}

		public void UpdateNote(Note updatedNote)
		{
			int index = notes.IndexOf(updatedNote);
			notes[index].Text = updatedNote.Text;
			//notes.First(note => notes.GetHashCode() == updatedNote.GetHashCode()).Text = "Hallo";
		}

		public void RemoveNote(Note note)
		{
			notes.Remove(note);
		}
	}
}
