using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleNotes.Models;
using SimpleNotes.ViewModels;

namespace SimpleNotes.Services
{
	public class DataService : IDataService
	{
		private List<Note> notes;

		public DataService()
		{
			notes = new List<Note>();
		}

		public async Task<IEnumerable<Note>> GetNotesAsync()
		{
			return notes;
		}

		public Task AddNote(Note note)
		{
			throw new System.NotImplementedException();
		}

		public async Task SetNotes(IEnumerable<Note> notesToSet)
		{
			notes = notesToSet != null ? new List<Note>(notesToSet) : new List<Note>();
		}

		public async Task SaveNote(Note note)
		{
			notes.Add(note);
		}

		public async Task UpdateNote(Note updatedNote)
		{
			int index = notes.IndexOf(updatedNote);
			notes[index].Text = updatedNote.Text;
		}

		public async Task RemoveNote(Note note)
		{
			notes.Remove(note);
		}
	}
}
