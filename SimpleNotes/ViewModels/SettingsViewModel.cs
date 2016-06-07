using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotes.ViewModels
{
	class SettingsViewModel
	{
		public int ReadNotesCounter
		{
			get
			{
				return Global.NumberOfShownNotes;
			}
			set
			{
				Global.NumberOfShownNotes = value;
			}
		}
	}
}
