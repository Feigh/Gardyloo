using AutoMapper;
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

			var mockset = new Mock<GameSettings>();

			var mockhandlrLog = new Mock<ILogger<RoomHandler>>();
			mockhandlrLog.Setup(x => x.Log<It.IsAnyType>(
				It.IsAny<LogLevel>(),
				It.IsAny<EventId>(),
				It.IsAny<It.IsAnyType>(),
				It.IsAny<Exception>(),
				(Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));
			_handler = new RoomHandler(mockhandlrLog.Object);

			var mocksetting = new Mock<IDataReader<GameSettings>>();
			mocksetting.Setup(x => x.GetItem(It.IsAny<string>())).Returns(new GameSettings() { id=Guid.NewGuid() });

			var mockmap = new Mock<IMapper>();

			_sut = new GameRoomController(mockLog.Object, _handler, mocksetting.Object, mockmap.Object);
		}
		[Fact]
		public void Task_Get_GenereateARoomWithRandomNameAndRedturnThatName()
		{
			var result = _sut.Get();

			Assert.NotNull(result);

			Assert.IsType< JsonResult>(result);

			var result2 = (JsonResult)result;
			var result3 = (Room)result2.Value;

			Assert.True(result3.Name!="AAAA");// Controll that is has not testvalue
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
	}
}
