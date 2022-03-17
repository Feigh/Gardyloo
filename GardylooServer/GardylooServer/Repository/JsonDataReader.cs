using GardylooServer.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Repository
{
	public class JsonDataReader<T> : IDataReader<T> where T : class
	{
		private readonly ILogger<JsonDataReader<T>> _logger;

		public JsonDataReader(ILogger<JsonDataReader<T>> logger, IConfiguration config)
		{
			_logger = logger;
			ConnectionString = config.GetConnectionString("DefaultConnection");
			//ConnectionString = ReadDataFile();
		}

		public string ConnectionString { get; set; }

		public T AddItem(T item)
		{
			throw new NotImplementedException();
		}

		public void DeleteItem(T item)
		{
			throw new NotImplementedException();
		}

		private string ReadDataFile()
		{
			try
			{
				JsonSerializer serializer = new JsonSerializer();
				var stuff = serializer.Deserialize<Dictionary<string, string>>(new JsonTextReader(new StreamReader(ConnectionString)));

				var keyvalue = "";

				if(typeof(T) == typeof(GameSettings) || typeof(T) == typeof(GameSettingsObject))
				{
					stuff.TryGetValue("Settings", out keyvalue);
				}
				else if(typeof(T) == typeof(GameTag) || typeof(T) == typeof(GameTagObject))
				{
					stuff.TryGetValue("Tags", out keyvalue);
				}

				return keyvalue;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in JsonDataReader : {ex.Message}");
				throw new Exception(ex.Message);
			}
		}

		public IEnumerable<T> GetAllItem()
		{
			try
			{
				JsonSerializer serializer = new JsonSerializer();
				var result = serializer.Deserialize<IList<T>>(new JsonTextReader(new StreamReader(ReadDataFile())));
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in JsonDataReader : {ex.Message}");
				throw new Exception(ex.Message);
			}
		}

		public T GetItem(string id)
		{
			try
			{
				JsonSerializer serializer = new JsonSerializer();
				var result = serializer.Deserialize<T>(new JsonTextReader(new StreamReader(ReadDataFile())));
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in JsonDataReader : {ex.Message}");
				throw new Exception(ex.Message);
			}
		}

		public T UpdateItem(T item)
		{
			throw new NotImplementedException();
		}
	}
}
