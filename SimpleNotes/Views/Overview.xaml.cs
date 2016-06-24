using Windows.UI.Xaml.Controls;
using SimpleNotes.Views;

namespace SimpleNotes
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

		private void OnMenuItemSelected(object sender, SelectionChangedEventArgs e)
		{
			if (e.AddedItems[0] is string)
			{
				string item = e.AddedItems[0] as string;

				switch(item)
				{
					case "Create Note":
						Frame.Navigate(typeof(NewNote));
						break;

					case "Read Notes":
						Frame.Navigate(typeof(ReadNotes));
						break;

					case "Map Overview":
						Frame.Navigate(typeof(MapOverview));
						break;

					case "Settings":
						Frame.Navigate(typeof(Settings));
						break;
				}
			}
		}
	}
}
