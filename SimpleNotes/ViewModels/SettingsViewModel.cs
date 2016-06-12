using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleNotes.Models;
using SimpleNotes.Services;

namespace SimpleNotes.ViewModels
{
	public class SettingsViewModel
	{
		private readonly IStorageService storageService;
		private readonly IDataService dataService;

		public int NumberOfShownNotes { get; set; }
		public bool IsSortAscending { get; set; }

		public SettingsViewModel(IDataService dataService, IStorageService storageService)
		{
			this.storageService = storageService;
			this.dataService = dataService;
			LoadFromStorage();
		}

		public void SaveToStorage()
		{
			storageService.Write(nameof(NumberOfShownNotes), NumberOfShownNotes);
			storageService.Write(nameof(IsSortAscending), IsSortAscending);
			storageService.Write("notes", dataService.GetNotes());
		}

		public void LoadFromStorage()
		{
			NumberOfShownNotes = storageService.Read<int>(nameof(NumberOfShownNotes), 5);
			IsSortAscending = storageService.Read<bool>(nameof(IsSortAscending), false);
			dataService.SetNotes(storageService.Read<List<Note>>("notes"));
		}
	}
}
