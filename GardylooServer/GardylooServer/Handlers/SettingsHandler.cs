using GardylooServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public class SettingsHandler : ISettingsHandler
	{
		private IList<GameSettings> _settingList;
		public SettingsHandler()
		{
			_settingList = new List<GameSettings>();
		}

		public IList<GameSettings> SettingList {get{ return _settingList;} }

		public GameSettings ControllSettings(GameSettings settings)
		{
			throw new NotImplementedException();
		}

		public GameSettings GetNewSettings()
		{
			// Jag vill här ha en dataloadobject där jag skickar in att jag vill läsa en fil
			//men jag vill inte veta om datan är från en fil eller en databas jag vill bara ha tillbaka en settings fil
			// en ISettingsDataLoader där en fil har med file reader och en har db reader
			// connectsource, fil kollar att den hittar filen, db kollar att den hittar databasen
			// getstream, fil läser in en stream data och db hämtar ut strömdata
			// processstream, gör om filströmen till det önskade 
			// filereader och dbreader där båda tar in en T 
			throw new NotImplementedException();
		}

		public GameSettings UpdateSettings(GameSettings settings)
		{
			throw new NotImplementedException();
		}
	}
}
