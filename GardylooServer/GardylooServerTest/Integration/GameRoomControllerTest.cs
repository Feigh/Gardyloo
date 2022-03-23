using AutoMapper;
using GardylooServer;
using GardylooServer.Controllers;
using GardylooServer.Entities;
using GardylooServer.Handlers;
using GardylooServer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GardylooServerTest.Integration
{
	public class GameRoomControllerTest
	{
		private readonly GameRoomController _sut;
		private readonly RoomHandler _handler;
		public GameRoomControllerTest()
		{
			var mockLog = new Mock<ILogger<GameRoomController>>();
			mockLog.Setup(x => x.Log<It.IsAnyType>(
				It.IsAny<LogLevel>(),
				It.IsAny<EventId>(),
				It.IsAny<It.IsAnyType>(),
				It.IsAny<Exception>(),
				(Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

			var mockhandlrLog = new Mock<ILogger<RoomHandler>>();
			mockhandlrLog.Setup(x => x.Log<It.IsAnyType>(
				It.IsAny<LogLevel>(),
				It.IsAny<EventId>(),
				It.IsAny<It.IsAnyType>(),
				It.IsAny<Exception>(),
				(Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));
			_handler = new RoomHandler(mockhandlrLog.Object);

			var mocksetting = new Mock<IDataReader<GameSettingsObject>>();
			mocksetting.Setup(x => x.GetItem(It.IsAny<string>())).Returns(new GameSettingsObject() { id= "8ba26130-be33-4cf6-9591-0b0cc3d26cde" });

			//auto mapper configuration
				var mockMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapperProfile());
			});
			var mapper = mockMapper.CreateMapper();

			_sut = new GameRoomController(mockLog.Object, _handler, mocksetting.Object, mapper);
		}
		[Fact]
		public void Task_Get_GenereateARoomWithRandomNameAndRedturnThatName()
		{
			var result = _sut.Get();

			Assert.NotNull(result);

			Assert.IsType<JsonResult>(result);

			var result2 = (JsonResult)result;
			var result3 = (Room)result2.Value;

			Assert.True(result3.Name != "AAAA");// Controll that is has not testvalue
			Assert.True(result3.Name.Length == 4);
			Assert.Matches("\\w{4}", result3.Name);

			Assert.NotNull(result3.Settings);
		}

		[Fact]
		public void Task_Get_ReturnTheRoomAtTheId()
		{
			var newroom = _sut.Get(); // CreateRoom

			var newroom2 = (JsonResult)newroom;
			var newroom3 = (Room)newroom2.Value;

			var result = _sut.Get(newroom3.Name); // CreateRoom

			Assert.NotNull(result);
			Assert.IsType<JsonResult>(result);

			var result2 = (JsonResult)result;
			var result3 = (Room)result2.Value;

			Assert.True(result3.Name == newroom3.Name);
			Assert.NotNull(result3.Settings);
		}

		[Fact]
		public void Task_Update_ChangeStateAndUpdateSettings()
		{
			var newroom = _sut.Get(); // CreateRoom

			var newroom2 = (JsonResult)newroom;
			var newroom3 = (GameRoomObject)newroom2.Value;

			var settingobj = new GameSettingsObject() { id = newroom3.Settings.id.ToString(), GoalPoint = 5, MaxPlayers = 10 };
			var roomobj = new GameRoomObject() { id = newroom3.id.ToString(), Name = newroom3.Name, GameStatus = newroom3.GameStatus, PlayerList = new List<PlayerObject>(), Settings=settingobj };

			var result = _sut.Post(roomobj);

			Assert.NotNull(result);
			Assert.IsType<JsonResult>(result);

			var result2 = (JsonResult)result;
			var result3 = (GameRoomObject)result2.Value;

			Assert.True(result3.Name == newroom3.Name);
			Assert.True(result3.GameStatus==GameStatusEnum.waitingtostart.ToString());
			Assert.NotNull(result3.Settings);

			Assert.True(result3.Settings.MaxPlayers==10);
			Assert.True(result3.Settings.GoalPoint==5);
		}
	}
}
