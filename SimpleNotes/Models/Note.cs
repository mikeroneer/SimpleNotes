using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotes.Models
{
	public class Note : IEquatable<Note>
	{
		public string Text { get; set; }

		public DateTime CreationDate { get; set; }

		public Note(DateTime date, string text)
		{
			CreationDate = date;
			Text = text;
		}

		public bool Equals(Note other)
		{
			return Text.Equals(other.Text) && CreationDate.Equals(other.CreationDate);
		}
	}
}
