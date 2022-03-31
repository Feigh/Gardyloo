using GardylooServer.Entities;
using GardylooServer.Handlers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Text.RegularExpressions;
using Xunit;

namespace GardylooServerTest.Unit
{
	public class RoomCreationTest
	{
		private readonly RoomHandler _sut;

		public RoomCreationTest()
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
		public void Task_GenerateName_ReturnFourLetters()
		{
			var result = _sut.GenerateRoomName();
			Assert.True(result.Length == 4);
			Assert.Matches("\\w{4}", result );
		}
		[Fact]
		public void Task_AddRoom_ReturnsValidRoom()
		{
			var mockset = new Mock<GameSettings>();
			var result = _sut.AddRoom("AAAA", mockset.Object);

			Assert.NotNull(result);
			Assert.True(result.RoomName == "AAAA");
		}
		[Fact]
		public void Task_AddRoom_RoomListHaveNewRoom()
		{
			var mockset = new Mock<GameSettings>();
			var result = _sut.AddRoom("AAAA", mockset.Object);

			Assert.NotNull(result);
			Assert.True(result.RoomName == "AAAA");
		}
	}
}
