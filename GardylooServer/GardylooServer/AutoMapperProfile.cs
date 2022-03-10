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

			CreateMap<GameSettings, GameSettingsObject>();
			CreateMap<GameSettingsObject, GameSettings>();

			CreateMap<GameTag, GameTagsObject>();
			CreateMap<GameTagsObject, GameTag>();

			CreateMap<Room, GameRoomObject>().ForMember(
				dest => dest.GameStatus,
				opt => opt.MapFrom(src => src.state.ToString())).ReverseMap();
			//CreateMap<GameRoomObject, Room>();

			CreateMap<Player, PlayerObject>();
			CreateMap<PlayerObject, Player>();


		}
	}
}
