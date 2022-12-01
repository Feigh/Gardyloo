using GardylooServer.Entities;
using GardylooServer.Handlers;
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
    public class RoomManagerDeleteRoomTest
    {
        private readonly RoomManager _sut;

        public RoomManagerDeleteRoomTest()
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
        public void Task_DeleteFromListWillDeleteIt()
        {
            var mockset = new Mock<GameSettings>();
            _sut.AddRoom("AAAA", mockset.Object);

            var result = _sut.RoomList.Where(x => x.RoomName == "AAAA").FirstOrDefault();

            Assert.NotNull(result);

            _sut.DeleteRoom("AAAA");

            result = _sut.RoomList.Where(x => x.RoomName == "AAAA").FirstOrDefault();

            Assert.Null(result);
        }

        [Fact]
        public void Task_IfRoomIsOlderThenConfigDelete()
        {
        }
    }
}
