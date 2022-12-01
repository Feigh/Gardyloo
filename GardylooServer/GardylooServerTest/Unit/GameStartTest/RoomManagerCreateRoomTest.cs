using Castle.Core.Resource;
using GardylooServer.Entities;
using GardylooServer.Handlers;
using GardylooServer.Repository;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GardylooServerTest.Unit.SetupGameTest
{
    public class RoomManagerCreateRoomTest
    {
        private readonly RoomManager _sut;

        public RoomManagerCreateRoomTest()
        {
            var mockLog = new Mock<ILogger<RoomManager>>();
            mockLog.Setup(x => x.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

            _sut = new RoomManager(mockLog.Object);
        }

        [Fact]
        public void Task_CreateRoomAddToListWithGeneratedNameAndStateSetup()
        {
            var mockset = new Mock<GameSettings>();
            var result = _sut.AddRoom("AAAA", mockset.Object);

            Assert.NotNull(result);
            Assert.True(result.RoomName == "AAAA");
            Assert.True(result.RoomEvent.RoomData.state == GameStatusEnum.gamesetup);
        }

        [Fact]
        public void Task_GenerateRoomNameReturnsListOfRandomNumbers()
        {
            var result = _sut.GenerateRoomName();
            Assert.True(result.Length == 4);
            Assert.Matches("\\w{4}", result);
        }

        [Fact]
        public void Task_GetRoomWillReturnTheRoomObject()
        {
            var mockset = new Mock<GameSettings>();
            _sut.AddRoom("AAAA", mockset.Object);

            var result = _sut.RoomList.Where(x => x.RoomName == "AAAA").FirstOrDefault();

            Assert.NotNull(result);
            Assert.True(result.RoomName == "AAAA");
        }

        [Fact]
        public void Task_CreateRoomWillReturnErrorWithNameThatAlreadyExist()
        {
            var mockset = new Mock<GameSettings>();
            _sut.AddRoom("AAAA", mockset.Object);

            var mockset2 = new Mock<GameSettings>();

            var caughtException = Assert.Throws<Exception>(() => _sut.AddRoom("AAAA", mockset2.Object));

            Assert.Equal("A valid name must be supplied.", caughtException.Message);

        }
    }
}
