using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
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

					case "Search for a Note":
						Frame.Navigate(typeof(SearchNote));
						break;

					case "Settings":
						Frame.Navigate(typeof(Settings));
						break;
				}
			}
		}
	}
}
