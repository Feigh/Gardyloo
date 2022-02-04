using GardylooServer.Entities;
using System.Collections.Generic;

namespace GardylooServer.Handlers
{
	public interface ISettingsHandler
	{
		public IList<GameSettings> SettingList { get; }
		public GameSettings GetNewSettings();// Skapar en ny settings object utifrån den sparade default settingen
		public GameSettings UpdateSettings(GameSettings settings);//uppdatera settings med dina ändringar
		public GameSettings ControllSettings(GameSettings settings);//Kontrollera att settings objektet du ahr följer standard
	}
}