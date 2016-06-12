using GalaSoft.MvvmLight;
using SimpleNotes.Models;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight.Views;
using SimpleNotes.Services;

namespace SimpleNotes.ViewModels
{
	public class NoteDetailsViewModel : ViewModelBase, IInitializable
	{
		private readonly INavigationService navigationService;
		private readonly IDataService dataService;

		public string PageHeading { get; set; }
		public string NoteText { get; set; }
		public DateTime CurrentDate { get; set; }

		private Mode mode;
		private Note editNote;

		public NoteDetailsViewModel(INavigationService navigationService, IDataService dataService)
		{
			this.navigationService = navigationService;
			this.dataService = dataService;

			((App)Application.Current).OnBackRequested += (sender, e) =>
			{
				if (!e.Handled)
				{
					CancelCreateNote();
					e.Handled = true;
				}
			};
		}

		public void Initialize(object parameter)
		{
			if (parameter is Note)
			{
				editNote = parameter as Note;
				NoteText = editNote.Text;
				CurrentDate = editNote.CreationDate;

				mode = Mode.Edit;
				PageHeading = "Edit Note";
			}
			else
			{
				mode = Mode.Create;
				PageHeading = "Create Note";
				CurrentDate = DateTime.Now;
			}
		}

		public async void SaveNote()
		{
			if(string.IsNullOrEmpty(NoteText))
			{
				var dialog = new MessageDialog("Do empty notes really make sense? ;-)", "Honestly");
				await dialog.ShowAsync();
			}
			else
			{
				switch (mode)
				{
					case Mode.Create:
						dataService.SaveNote(new Note(CurrentDate, NoteText));
						break;

					case Mode.Edit:
						editNote.Text = NoteText;
						dataService.UpdateNote(editNote);
						navigationService.GoBack();
						break;
				}
				
				NoteText = string.Empty;
				CurrentDate = DateTime.Now;
			}
		}

		public async void CancelCreateNote()
		{
			if(!string.IsNullOrEmpty(NoteText))
			{
				if (mode == Mode.Create || (mode == Mode.Edit && !editNote.Text.Equals(NoteText)))
				{
					var saveChangesDialog =
						new MessageDialog("You've worked on that note with love and now you'll kick it? Wouldn't you like to safe?",
							"Save changes?");

					saveChangesDialog.Commands.Add(new UICommand("Yes", (cmd) => SaveNote()));
					saveChangesDialog.Commands.Add(new UICommand("No"));

					await saveChangesDialog.ShowAsync();
				}
			}

			navigationService.GoBack();
		}

		private enum Mode { Create, Edit };
	}
}
