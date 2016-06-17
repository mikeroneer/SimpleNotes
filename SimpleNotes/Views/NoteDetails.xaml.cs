using SimpleNotes.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SimpleNotes.Views
{
	public sealed partial class NewNote : Page
	{
		private NoteDetailsViewModel ViewModel => DataContext as NoteDetailsViewModel;

		public NewNote()
		{
			this.InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			ViewModel.Initialize(e.Parameter);
		}
	}
}
