using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SimpleNotes.Models;
using System;
using System.ServiceModel.Channels;
using System.Windows.Input;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using GalaSoft.MvvmLight.Views;
using SimpleNotes.Services;

namespace SimpleNotes.ViewModels
{
	public class NewNoteViewModel : ViewModelBase, IInitializable
	{
		private readonly INavigationService navigationService;
		private readonly IDataService dataService;

		public string PageHeading { get; set; }
		public string NoteText { get; set; }
		public DateTime CurrentDate { get; set; }

		private Mode mode;
		private Note editNote;

		public NewNoteViewModel(INavigationService navigationService, IDataService dataService)
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

		public void Initialise(object parameter)
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

				/*DispatcherTimer dt = new DispatcherTimer();
				dt.Interval = new TimeSpan(0, 0, 1);
				dt.Tick += (sender, e) =>
				{
					CurrentDate = DateTime.Now;
				};

				dt.Start();*/
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
				var discardChangesDialog = new MessageDialog("You've worked on that note with love and now you'll kick it? Wouldn't you like to safe?", "Save changes?");

				discardChangesDialog.Commands.Add(new UICommand("Yes", (cmd) => SaveNote()));
				discardChangesDialog.Commands.Add(new UICommand("No"));

				await discardChangesDialog.ShowAsync();
			}

			navigationService.GoBack();
		}

		private enum Mode { Create, Edit };
	}
}
