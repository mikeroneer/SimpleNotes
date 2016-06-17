using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using SimpleNotes.ViewModels;

namespace SimpleNotes.Views
{
	public sealed partial class ReadNotes : Page
	{
		private ReadNotesViewModel ViewModel => DataContext as ReadNotesViewModel;

		public ReadNotes()
		{
			this.InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			ViewModel.LoadData();
		}
	}
}
