using GardylooServer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using GardylooServer.Entities;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace GardylooServerTest.Unit
{
	public class SettingsJsonDataReaderTest
	{
		private readonly OldJsonDataReader<GameSettingsObject> _sut;

		public SettingsJsonDataReaderTest()
		{
			var mockLog = new Mock<ILogger<OldJsonDataReader<GameSettingsObject>>>();
			mockLog.Setup(x => x.Log<It.IsAnyType>(
				It.IsAny<LogLevel>(),
				It.IsAny<EventId>(),
				It.IsAny<It.IsAnyType>(),
				It.IsAny<Exception>(),
				(Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

			_sut = new OldJsonDataReader<GameSettingsObject>(mockLog.Object);
		}

		[Fact]
		public void Task_CanFindFileOnIO()
		{
			var result = _sut.ConnectSource("../../../TestData/testsettings.json");

			Assert.NotNull(result);
		}

		[Fact]
		public void Task_CanReadData()
		{
			var result = _sut.ProcessStream(_sut.ConnectSource("../../../TestData/testsettings2.json"));


			Assert.NotNull(result);

			Assert.True(result.GoalPoint == 3);
			Assert.True(result.id.ToString() == "33574ed3-72db-4b4c-bd91-b2a84ba38213");
			Assert.True(result.ExcludedTags.Count > 0);
			Assert.Contains(result.ExcludedTags, item => item.TagText == "political");
		}
	}
}
