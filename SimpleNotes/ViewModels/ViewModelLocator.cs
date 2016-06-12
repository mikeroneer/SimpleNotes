
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SimpleNotes.Common;
using SimpleNotes.Services;
using SimpleNotes.Views;

namespace SimpleNotes.ViewModels
{
	public class ViewModelLocator
	{
		public OverviewViewModel OverviewViewModel => ServiceLocator.Current.GetInstance<OverviewViewModel>();
		public NewNoteViewModel NewNoteViewModel => ServiceLocator.Current.GetInstance<NewNoteViewModel>();
		public ReadNotesViewModel ReadNotesViewModel => ServiceLocator.Current.GetInstance<ReadNotesViewModel>();
		public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();

		static ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<OverviewViewModel>();
			SimpleIoc.Default.Register<NewNoteViewModel>();
			SimpleIoc.Default.Register<ReadNotesViewModel>();
			SimpleIoc.Default.Register<SettingsViewModel>();

			SimpleIoc.Default.Register(RegisterNavigationService);
			SimpleIoc.Default.Register<IDataService, DataService>();
			SimpleIoc.Default.Register<IStorageService, LocalStorageService>();
		}

		private static INavigationService RegisterNavigationService()
		{
			var service = new NavigationService();
			service.Configure(Navigation.EditNote, typeof(NewNote));
			service.Configure(Navigation.ReadNotes, typeof(ReadNotes));
			service.Configure(Navigation.Settings, typeof(Settings));

			return service;
		}
	}
}
