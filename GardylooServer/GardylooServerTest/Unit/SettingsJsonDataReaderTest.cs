using GardylooServer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using GardylooServer.Entities;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace GardylooServerTest.Unit
{
	public class SettingsJsonDataReaderTest
	{
		private readonly JsonDataReader<GameSettings> _sut;

		public SettingsJsonDataReaderTest()
		{
			var mockLog = new Mock<ILogger<JsonDataReader<GameSettings>>>();
			mockLog.Setup(x => x.Log<It.IsAnyType>(
				It.IsAny<LogLevel>(),
				It.IsAny<EventId>(),
				It.IsAny<It.IsAnyType>(),			
				It.IsAny<Exception>(),
				(Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

			_sut = new JsonDataReader<GameSettings>(mockLog.Object);
		}

		[Fact]
		public void Task_CanFindFileOnIO()
		{
			var result = _sut.ConnectSource("../TestData/testsettings.json");

			Assert.True(result != null);
		}
	}
}
