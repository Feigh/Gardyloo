using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Repository
{
	interface ISettingsReader<T>
	{
		public T GetDefaultSettings();
		public T GetSettings(string id);
		public IEnumerable<T> GetSettings();
	}
}
