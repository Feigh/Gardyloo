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
    public class RoomEventAddPlayerTest
    {
        private readonly RoomEvent _sut;

        public RoomEventAddPlayerTest()
        {
            var mockset = new Mock<GameSettings>();
            _sut = new RoomEvent("AAAA", mockset.Object);
        }


        [Fact]
        public void AddPlayer_WillAddToPlayerList()
        {

        }
        [Fact]
        public void AddPlayer_WillSetFirstPlayerAsLeader()
        {

        }
        [Fact]
        public void AddPlayer_WillNotSetFirstPlayerasLeader()
        {

        }
        [Fact]
        public void AddPlayer_ReturnErrorIfPlayerExist()
        {

        }
        [Fact]
        public void AddPlayer_ReturnCantJoinIfGameIsNotInWaitingForPlayerState()
        {

        }
        [Fact]
        public void AddPlayer_ReturnErrorIfBreakingNameConvention()
        {

        }

    }
}
