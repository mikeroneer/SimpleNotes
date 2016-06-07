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

namespace SimpleNotes.ViewModels
{
	public class NewNoteViewModel : ViewModelBase
	{
		public string NoteText { get; set; }
		public DateTime CurrentDate { get; set; } = DateTime.Now;

		public ICommand SaveNoteCommand { get; set; }
		public ICommand CancelCreateNoteCommand { get; set; }

		public NewNoteViewModel()
		{
			DispatcherTimer dt = new DispatcherTimer();
			dt.Interval = new TimeSpan(0, 0, 1);
			dt.Tick += (sender, e) =>
			{
				CurrentDate = DateTime.Now;
			};

			dt.Start();

			SaveNoteCommand = new RelayCommand(SaveNote);
			CancelCreateNoteCommand = new RelayCommand(CancelCreateNote);

			((App)Application.Current).OnBackRequested += (sender, e) =>
			{
				if (!e.Handled)
				{
					CancelCreateNote();
					e.Handled = true;
				}
			};
		}

		private async void SaveNote()
		{
			if(string.IsNullOrEmpty(NoteText))
			{
				var dialog = new MessageDialog("Do empty notes really make sense? ;-)", "Honestly");
				await dialog.ShowAsync();
			}
			else
			{
				Global.Notes.Add(new Note(CurrentDate, NoteText));
				NoteText = string.Empty;
			}
		}

		public async void CancelCreateNote()
		{
			if(!string.IsNullOrEmpty(NoteText))
			{
				var discardChangesDialog = new MessageDialog("You've worked on that note with love and now you'll kick it? Wouldn't you like to safe?", "Save changes?");

				discardChangesDialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler((cmd) => SaveNote())));
				discardChangesDialog.Commands.Add(new UICommand("No"));

				await discardChangesDialog.ShowAsync();
			}

			GoBack();
		}

		private void GoBack()
		{
			var frame = Window.Current.Content as Frame;

			if (frame.CanGoBack)
			{
				frame.GoBack();
			}
		}
	}
}
