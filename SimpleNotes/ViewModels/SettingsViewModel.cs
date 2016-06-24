using System.Collections.Generic;
using GalaSoft.MvvmLight;
using SimpleNotes.Models;
using SimpleNotes.Services;

namespace SimpleNotes.ViewModels
{
	public class SettingsViewModel : ViewModelBase
	{
		private readonly IStorageService storageService;
		private readonly IDataService dataService;

		public int NumberOfShownNotes { get; set; } = 5;
		public bool IsSortAscending { get; set; }

		public string TenantId => "s1510237031";

		public SettingsViewModel(IStorageService storageService)
		{
			this.storageService = storageService;
		}

		public void SaveToStorage()
		{
			storageService.Write(nameof(NumberOfShownNotes), NumberOfShownNotes);
			storageService.Write(nameof(IsSortAscending), IsSortAscending);
			storageService.Write("notes", dataService.GetNotesAsync().Result);
		}

		public void LoadFromStorage()
		{
			NumberOfShownNotes = storageService.Read<int>(nameof(NumberOfShownNotes), 5);
			IsSortAscending = storageService.Read<bool>(nameof(IsSortAscending), false);
		}
	}
}
