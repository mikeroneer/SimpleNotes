using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotes.Models
{
	class Note
	{
		public string Text { get; set; }

		public DateTime CreationDate { get; set; }

		public Note(DateTime date, string text)
		{
			CreationDate = date;
			Text = text;
		}
	}
}
