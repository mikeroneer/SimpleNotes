using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleNotes.Models;

namespace SimpleNotes.Services
{
	public interface IDataService
	{
		Task<IEnumerable<Note>> GetNotes();
		Task AddNote(Note note);
		Task SaveNote(Note note);
		Task UpdateNote(Note note);
		Task RemoveNote(Note note);
		Task SetNotes(IEnumerable<Note> notes);
	}
}
