using GalaSoft.MvvmLight;
using SimpleNotes.Services;

namespace SimpleNotes.ViewModels
{
	public class SettingsViewModel : ViewModelBase
	{
		private readonly IStorageService storageService;
		private readonly IDataService dataService;

		public int NumberOfShownNotes { get; set; } = 5;
		public bool IsSortAscending { get; set; }
		public string TenantId { get; set; }

		public SettingsViewModel(IStorageService storageService)
		{
			this.storageService = storageService;
			LoadFromStorage();
		}

		public void SaveToStorage()
		{
			storageService.Write(nameof(NumberOfShownNotes), NumberOfShownNotes);
			storageService.Write(nameof(IsSortAscending), IsSortAscending);
			storageService.Write(nameof(TenantId), TenantId);
		}

		public void LoadFromStorage()
		{
			NumberOfShownNotes = storageService.Read<int>(nameof(NumberOfShownNotes), 5);
			IsSortAscending = storageService.Read<bool>(nameof(IsSortAscending), false);
			TenantId = storageService.Read<string>(nameof(TenantId), "s1510237031");
		}
	}
}
