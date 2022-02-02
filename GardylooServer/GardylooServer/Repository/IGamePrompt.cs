using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GardylooServer.Entities;

namespace GardylooServer.Repository
{
	interface IGamePrompt
	{
        IEnumerable GetPrompt();

        GamePrompsObject GetPromptByID(int customerId);

        void InsertSPrompt(GameSoundObject customer);

        void DeletePrompt(int customerId);

        void UpdatePrompt(GameSoundObject customer);

        void Save();
    }
}
