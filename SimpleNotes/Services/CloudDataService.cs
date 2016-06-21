using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleNotes.Models;
using SimpleNotes.ViewModels;

namespace SimpleNotes.Services
{
	public class CloudDataService : IDataService
	{
		private readonly SettingsViewModel settings;

		private string Uri => $"http://notesservice.azurewebsites.net/api/{settings.TenantId}/Notes";

		private readonly HttpClient client = new HttpClient();


		public CloudDataService(SettingsViewModel settings)
		{
			this.settings = settings;
		}

		public async Task<IEnumerable<Note>> GetNotes()
		{
			var json = await client.GetStringAsync(Uri);
			var notes = JsonConvert.DeserializeObject<IEnumerable<Note>>(json);
			return notes;
		}

		public async Task AddNote(Note note)
		{
			
		}

		public async Task SaveNote(Note note)
		{
			var json = JsonConvert.SerializeObject(note);
			var response = await client.PostAsync(Uri, new JsonContent(json));
			var s = response.Content;

			var x = response;
		}

		public async Task RemoveNote(Note note)
		{
			await client.DeleteAsync($"{Uri}/{note.Id}");
		}

		public async Task UpdateNote(Note note)
		{
			var json = JsonConvert.SerializeObject(note);
			var response = await client.PutAsync($"{Uri}/{note.Id}", new JsonContent(json));

			var x = response;
		}

		public Task SetNotes(IEnumerable<Note> notes)
		{
			throw new NotImplementedException();
		}
	}

	public class JsonContent : StringContent
	{
		public JsonContent(string content) : this(content, Encoding.UTF8) { }

		private JsonContent(string content, Encoding encoding, string mediaType = "application/json") : base(content, encoding, mediaType) { }
	}
}
