using GardylooServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public interface IGameHandler
	{
		public GameStatusEnum CurrentGameState { get; }

		public GameStatusEnum UpdateGameState(GameStatusEnum state);
	}
}
