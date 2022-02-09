using GardylooServer.Handlers;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Repository
{
	public class OldJsonDataReader<T> : IDataLoaderHandler<T, JsonTextReader>
	{
		private readonly ILogger<OldJsonDataReader<T>> _logger;
		public OldJsonDataReader(ILogger<OldJsonDataReader<T>> logger)
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
				_logger.LogError($"Error in JsonDataReader : {ex.Message}");
				return null;
			}
		}

		public T ProcessStream(JsonTextReader data)
		{
			try
			{

				JsonSerializer serializer = new JsonSerializer();
				return serializer.Deserialize<T>((data));
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in JsonDataReader : {ex.Message}");
				throw new Exception("Could not deserialize Json file");
			}
		}

		public JsonTextReader ReadStream(JsonTextReader source)
		{
			throw new NotImplementedException();
		}
	}
}
