using AutoMapper;
using GardylooServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer
{
	public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<GameSettings, GameSettingsObject>();
            CreateMap<GameSettingsObject, GameSettings>();

            CreateMap<GameTag, GameTagsObject>();
            CreateMap<GameTagsObject, GameTag>();
        }
	}
}
