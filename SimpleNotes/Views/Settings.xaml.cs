using Windows.UI.Xaml.Controls;
using SimpleNotes.ViewModels;

namespace SimpleNotes.Views
{
	public sealed partial class Settings : Page
	{
		private SettingsViewModel ViewModel => DataContext as SettingsViewModel;
		public Settings()
		{
			this.InitializeComponent();
		}
	}
}
