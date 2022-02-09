using GardylooServer.Entities;
using GardylooServer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace GardylooServerTest.Integration
{
	public class JsonSettingsReaderTest
	{
		private readonly JsonSettingsReader<GameSettings> _sut;

		public JsonSettingsReaderTest()
		{
			var mockLog = new Mock<ILogger<JsonSettingsReader<GameSettings>>>();
			mockLog.Setup(x => x.Log<It.IsAnyType>(
				It.IsAny<LogLevel>(),
				It.IsAny<EventId>(),
				It.IsAny<It.IsAnyType>(),
				It.IsAny<Exception>(),
				(Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));


			var appsettings = new Dictionary<string, string> {
				{"ConnectionStrings:DefaultConnection", "../../../TestData/testsettings2.json"}
			};

			var mockconfig = new ConfigurationBuilder()
			.AddInMemoryCollection(appsettings)
			.Build();

			_sut = new JsonSettingsReader<GameSettings>(mockLog.Object, mockconfig); 
		}

		[Fact]
		public void Task_GetDefaultSettings_ReturnsTheSettingsFromTestfile()
		{
			var result = _sut.GetDefaultSettings();

			Assert.NotNull(result);

			Assert.True(result.GoalPoint == 3);
			Assert.True(result.id.ToString() == "33574ed3-72db-4b4c-bd91-b2a84ba38213");
			Assert.True(result.ExcludedTags.Count > 0);
			Assert.Contains(result.ExcludedTags, item => item.TagText == "political");
		}
	}


}
