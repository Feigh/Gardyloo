using GardylooServer.Handlers;
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
			_sut = new RoomHandler();
		}

		[Fact]
		public void Task_GenerateName_ReturnFourLetters()
		{
			var result = _sut.GenerateRoomName();
			Assert.True(result.Length == 4);
			Assert.Matches("\\w{4}", result );
		}
		[Fact]
		public void Task_AddRoom_AddValidRoom()
		{
			//var result = _sut.AddRoom();
		}
	}
}
