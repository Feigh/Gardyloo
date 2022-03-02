using System;
using System.Collections.Generic;
using System.Text;
using GardylooServer.Entities;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using GardylooServer.Repository;
using GardylooServer.Handlers;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace GardylooServerTest.Unit
{
	public class JsonSettingsReaderTest
	{
		private readonly JsonDataReader<GameSettings> _sut;
		public JsonSettingsReaderTest()
		{
			var mockLog = new Mock<ILogger<JsonDataReader<GameSettings>>>();
			mockLog.Setup(x => x.Log<It.IsAnyType>(
				It.IsAny<LogLevel>(),
				It.IsAny<EventId>(),
				It.IsAny<It.IsAnyType>(),
				It.IsAny<Exception>(),
				(Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

			var appsettings = new Dictionary<string, string> {
				{"ConnectionStrings:DefaultConnection", "../../../TestData/settings/testsettings2.json"}
			};

			var mockconfig = new ConfigurationBuilder()
			.AddInMemoryCollection(appsettings)
			.Build();

			_sut = new JsonDataReader<GameSettings>(mockLog.Object, mockconfig);
		}

		[Fact]
		public void Task_GetDefaultSettingsFile()
		{
			var result = (GameSettings)_sut.GetItem("");

			Assert.True(result.GoalPoint == 3);
			Assert.True(result.id.ToString() == "33574ed3-72db-4b4c-bd91-b2a84ba38213");
			Assert.True(result.ExcludedTags.Count > 0);
			Assert.Contains(result.ExcludedTags, item => item.Text == "political");
		}

		[Fact]
		public void Task_ChangeFileSettings()
		{
			_sut.ConnectionString = "../../../TestData/settings/testsettings3.json";
			var result = (GameSettings)_sut.GetItem("");

			Assert.True(result.GoalPoint == 5);
			Assert.True(result.id.ToString() == "c861662f-5088-4594-8bd0-4b01ac9a2261");
			Assert.True(result.SelectedTags.Count > 1);
			Assert.Contains(result.SelectedTags, item => item.Text == "General");
		}
	}
}
