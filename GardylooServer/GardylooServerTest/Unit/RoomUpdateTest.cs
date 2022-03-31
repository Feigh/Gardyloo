using GardylooServer.Entities;
using GardylooServer.Handlers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace GardylooServerTest.Unit
{
	public class RoomUpdateTest
	{
		private readonly RoomHandler _sut;
		public RoomUpdateTest()
		{
			var mockLog = new Mock<ILogger<RoomHandler>>();
			mockLog.Setup(x => x.Log<It.IsAnyType>(
				It.IsAny<LogLevel>(),
				It.IsAny<EventId>(),
				It.IsAny<It.IsAnyType>(),
				It.IsAny<Exception>(),
				(Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

			_sut = new RoomHandler(mockLog.Object);
		}

		[Fact]
		public void Task_Upate_UpdatesSettingsAndChangesState()
		{
			var settings = new GameSettings();

			var room = _sut.AddRoom("AAAA", settings).RoomData;

			room.Settings = new GameSettings() { GoalPoint = 8, MaxPlayers = 10 };

			var result = _sut.RoomList.Where(x => x.RoomName=="AAAA").FirstOrDefault().UpdateRoom(room);

			Assert.NotNull(result);
			Assert.True(result.Name == "AAAA");

			Assert.True(result.Settings.GoalPoint == 8);
			Assert.True(result.Settings.MaxPlayers == 10);
			Assert.True(result.state == GameStatusEnum.waitingtostart);
		}

		[Fact]
		public void Task_Upate_IfRoomNotExistError()
		{
			var settings = new GameSettings();

			var room = _sut.AddRoom("AAAA", settings).RoomData;

			room.Settings = new GameSettings() { GoalPoint = 8, MaxPlayers = 10 };

			var newroom = new Room("BBBB", new GameSettings());

			Assert.Throws<ArgumentNullException>(() => _sut.RoomList.Where(x => x.RoomName == "AAAA").FirstOrDefault().UpdateRoom(newroom));

		}
	}
}
