using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Entities
{
	public class GameEnteties
	{
	}

	public enum GameStatusEnum
	{
		gamesteup,
		gameinitalizing,
		waitingtostart,
		gamestart,
		leaderprompt,
		playeranswere,
		leaderanswere,
		gamepoint,
		gamevictory,
		gamefinish
	}

	public class Room
	{
		Guid id;
		string Name;
		string Settings;
		GameStatusEnum state;
		IEnumerable<Player> PlayerList;
	}

	public class Player
	{
		Guid id;
		string name;
		bool leader;
	}

}
