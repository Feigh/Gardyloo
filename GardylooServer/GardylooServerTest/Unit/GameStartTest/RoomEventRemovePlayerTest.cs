using GardylooServer.Entities;
using GardylooServer.Handlers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GardylooServerTest.Unit.SetupGameTest
{
    public class RoomEventRemovePlayerTest
    {
        private readonly RoomEvent _sut;

        public RoomEventRemovePlayerTest()
        {
            var mockset = new Mock<GameSettings>();
            _sut = new RoomEvent("AAAA", mockset.Object);
        }

        [Fact]
        public void RemovePlayer_WillSetPlayerAsInactive()
        {

        }

        [Fact]
        public void RemovePlayer_WillReturnErrorIfPlayerNotExist()
        {

        }

    }
}
