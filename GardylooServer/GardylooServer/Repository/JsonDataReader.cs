using GardylooServer.Handlers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Repository
{
	public class JsonDataReader<T> : IDataLoaderHandler<T, JsonTextReader>
	{
		private readonly ILogger<JsonDataReader<T>> _logger;
		public JsonDataReader(ILogger<JsonDataReader<T>> logger)
		{
			_logger = logger;
		}

		public JsonTextReader ConnectSource(string source)
		{
			try
			{
				return new JsonTextReader(new StreamReader(source));
			}
			catch(Exception ex)
			{
				_logger.LogError($"Error in JsonDataReader : {ex.InnerException.Message}");
				return null;
			}
		}

		public T ProcessStream(JsonTextReader data)
		{
			throw new NotImplementedException();
		}

		public JsonTextReader ReadStream(JsonTextReader source)
		{
			throw new NotImplementedException();
		}
	}
}
