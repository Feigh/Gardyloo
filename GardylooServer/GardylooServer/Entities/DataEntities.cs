using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Entities
{

	public class GameSoundObject
	{
		Guid Id;
		string Title;
		string UnderTitle;
		string FileName;
		string Path;
		string Creator;
		IEnumerable<GameTagsObject> Tags;
	}

	public class GamePrompsObject
	{
		Guid Id;
		string Text;
		string Creator;
		IEnumerable<GameTagsObject> Tags;
	}


	public class GameTagsObject
	{
		Guid TagId;
		string TagText;
	}
}
