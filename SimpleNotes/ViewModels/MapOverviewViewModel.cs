using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using SimpleNotes.Common;
using SimpleNotes.Models;
using SimpleNotes.Services;

namespace SimpleNotes.ViewModels
{
	public class MapOverviewViewModel : ViewModelBase, IInitializable
	{
		private readonly IDataService dataService;
		private readonly INavigationService navigationService;

		public string MapServiceToken => Config.MapServiceToken;

		public ObservableCollection<Note> AllNotes { get; set; }

		public MapOverviewViewModel(INavigationService navigationService, IDataService dataService)
		{
			this.navigationService = navigationService;
			this.dataService = dataService;

			Initialize(null);
		}

		public async void Initialize(object parameter)
		{
			var notes = await dataService.GetNotesAsync();

			AllNotes = new ObservableCollection<Note>(notes);
			Messenger.Default.Send("zoomToFit");
		}

		public void OnPushpinTapped(Note note)
		{
			navigationService.NavigateTo(Navigation.NoteDetails, note);
		}
	}
}
