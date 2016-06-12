using Windows.UI.Xaml.Controls;
using SimpleNotes.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SimpleNotes
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
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

					case "Settings":
						Frame.Navigate(typeof(Settings));
						break;
				}
			}
		}
	}
}
