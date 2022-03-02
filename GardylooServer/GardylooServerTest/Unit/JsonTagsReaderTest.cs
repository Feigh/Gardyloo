using GardylooServer.Entities;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using GardylooServer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace GardylooServerTest.Unit
{
	public class JsonTagsReaderTest
	{
		private readonly JsonDataReader<GameTagsObject> _sut;

		public JsonTagsReaderTest()
		{
			var mockLog = new Mock<ILogger<JsonDataReader<GameTagsObject>>>();
			mockLog.Setup(x => x.Log<It.IsAnyType>(
				It.IsAny<LogLevel>(),
				It.IsAny<EventId>(),
				It.IsAny<It.IsAnyType>(),
				It.IsAny<Exception>(),
				(Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

			var appsettings = new Dictionary<string, string> {
				{"ConnectionStrings:DefaultConnection", "../../../TestData/tags/testtags1.json"}
			};

			var mockconfig = new ConfigurationBuilder()
			.AddInMemoryCollection(appsettings)
			.Build();

			_sut = new JsonDataReader<GameTagsObject>(mockLog.Object, mockconfig);
		}

		[Fact]
		public void Task_GetAllTagsFromTest()
		{
			var result = (IList<GameTagsObject>)_sut.GetAllItem();

			Assert.True(result.Count == 8);
			Assert.Contains(result, item => item.Text == "General");
			Assert.Contains(result, item => item.Id == "e1986661-d161-4aeb-872d-a37e9985a3ff");
		}

	}
}
