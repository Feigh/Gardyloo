using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Entities
{

	public class GameSoundObject
	{
		public string Id;
		public string Title;
		public string UnderTitle;
		public string FileName;
		public string Path;
		public string Creator;
		public IEnumerable<GameTagsObject> Tags;
	}

	public class GamePrompsObject
	{
		public string Id;
		public string Text;
		public string Creator;
		public IEnumerable<GameTagsObject> Tags;
	}


	public class GameTagsObject
	{
		[JsonProperty("id")]
		public string Id;
		[JsonProperty("name")]
		public string Text;
	}

	public class GameSettingsObject
	{
		[JsonProperty("id")]
		public string id { get; set; }
		[JsonProperty("goalpoint")]
		public int GoalPoint { get; set; }
		[JsonProperty("maxplayers")]
		public int MaxPlayers { get; set; }
		[JsonProperty("minplayers")]
		public int MinPlayers { get; set; }
		[JsonProperty("timelimit")]
		public double TimeLimit { get; set; }
		[JsonProperty("selectedtags")]
		public IList<GameTagsObject> SelectedTags { get; set; }
		[JsonProperty("excludedtags")]
		public IList<GameTagsObject> ExcludedTags { get; set; }

	}

	public class GameRoomObject
	{
		[JsonProperty("id")]
		public string id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("settings")]
		public GameSettingsObject Settings { get; set; }
		[JsonProperty("gamestatus")]
		public string GameStatus { get; set; }
		[JsonProperty("playerlist")]
		public List<PlayerObject> PlayerList { get; set; }
	}


	public class PlayerObject
	{
		[JsonProperty("id")]
		public string id { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
		[JsonProperty("leader")]
		public bool Leader { get; set; }

	}
}
