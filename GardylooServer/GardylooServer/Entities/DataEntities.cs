using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Entities
{

	public class GameSoundObject
	{
		public Guid Id;
		public string Title;
		public string UnderTitle;
		public string FileName;
		public string Path;
		public string Creator;
		public IEnumerable<GameTagsObject> Tags;
	}

	public class GamePrompsObject
	{
		public Guid Id;
		public string Text;
		public string Creator;
		public IEnumerable<GameTagsObject> Tags;
	}


	public class GameTagsObject
	{
		[JsonProperty("id")]
		public Guid TagId;
		[JsonProperty("name")]
		public string TagText;
	}

	public class GameSettingsObject
	{
		[JsonProperty("id")]
		public Guid id { get; set; }
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

}
