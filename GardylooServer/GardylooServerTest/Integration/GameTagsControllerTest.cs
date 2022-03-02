using AutoMapper;
using GardylooServer;
using GardylooServer.Controllers;
using GardylooServer.Entities;
using GardylooServer.Handlers;
using GardylooServer.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace GardylooServerTest.Integration
{
	public class GameTagsControllerTest
	{
		private readonly GameTagController _sut;

		public GameTagsControllerTest()
		{
			var mockLog = new Mock<ILogger<GameTagController>>();
			mockLog.Setup(x => x.Log<It.IsAnyType>(
				It.IsAny<LogLevel>(),
				It.IsAny<EventId>(),
				It.IsAny<It.IsAnyType>(),
				It.IsAny<Exception>(),
				(Func<It.IsAnyType, Exception, string>)It.IsAny<object>()));

			var mocktagLog = new Mock<ILogger<JsonDataReader<GameTagsObject>>>();
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

			var mackdatatag = new JsonDataReader<GameTagsObject>(mocktagLog.Object, mockconfig);

			var mockMapper = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapperProfile());
			});
			var mapper = mockMapper.CreateMapper();

			_sut = new GameTagController(mockLog.Object, mackdatatag, mapper);
		}

		[Fact]
		public void Task_GetWithId_GetSelectedTag()
		{
			var result = _sut.Get("e668a5af-6896-43c4-8a41-7ff7c11e1213");

			Assert.NotNull(result);

			Assert.IsType<JsonResult>(result);

			var result2 = (JsonResult)result;
			var result3 = (GameTag)result2.Value;

			Assert.True(result3.id == Guid.Parse("e668a5af-6896-43c4-8a41-7ff7c11e1213"));// Controll that is has not testvalue
			Assert.True(result3.text == "Horror");

		}

		[Fact]
		public void Task_Get_GetAllTags()
		{
			var result = _sut.Get();

			Assert.NotNull(result);

			Assert.IsType<JsonResult>(result);

			var result2 = (JsonResult)result;
			var result3 = (IList<GameTag>)result2.Value;

			Assert.True(result3.Count == 8);
			Assert.Contains(result3, item => item.text == "General");
			Assert.Contains(result3, item => item.id == Guid.Parse("e1986661-d161-4aeb-872d-a37e9985a3ff"));
		}
	}
}
