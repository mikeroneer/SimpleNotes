
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
		public NoteDetailsViewModel NewNoteViewModel => ServiceLocator.Current.GetInstance<NoteDetailsViewModel>();
		public ReadNotesViewModel ReadNotesViewModel => ServiceLocator.Current.GetInstance<ReadNotesViewModel>();
		public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();
		public MapOverviewViewModel MapOverviewViewModel => ServiceLocator.Current.GetInstance<MapOverviewViewModel>();

		static ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<OverviewViewModel>();
			SimpleIoc.Default.Register<NoteDetailsViewModel>();
			SimpleIoc.Default.Register<ReadNotesViewModel>();
			SimpleIoc.Default.Register<SettingsViewModel>();
			SimpleIoc.Default.Register<MapOverviewViewModel>();

			SimpleIoc.Default.Register(RegisterNavigationService);
			SimpleIoc.Default.Register<IDataService, CloudDataService>();
			SimpleIoc.Default.Register<IStorageService, LocalStorageService>();
		}

		private static INavigationService RegisterNavigationService()
		{
			var service = new NavigationService();
			service.Configure(Navigation.NoteDetails, typeof(NewNote));
			service.Configure(Navigation.ReadNotes, typeof(ReadNotes));
			service.Configure(Navigation.Settings, typeof(Settings));

			return service;
		}
	}
}
