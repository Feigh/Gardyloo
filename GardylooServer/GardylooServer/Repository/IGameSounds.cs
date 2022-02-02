using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GardylooServer.Entities;

namespace GardylooServer.Repository
{
	public interface IGameSounds
	{
        IEnumerable GetSounds();

		GameSoundObject GetSoundsByID(int customerId);

        void InsertSounds(GameSoundObject customer);

        void DeleteSounds(int customerId);

        void UpdateSounds(GameSoundObject customer);

        void Save();
    }
}
