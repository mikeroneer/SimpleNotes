using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNotes.Services
{
	public interface IInitializable
	{
		void Initialise(object parameter);
	}
}
