using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Repository
{
	public class JsonSettingsReader<T> : ISettingsReader<T>
	{
		private readonly ILogger<JsonSettingsReader<T>> _logger;
		private readonly OldJsonDataReader<T> _reader;
		public string ConnectionString { get; set; }

		public JsonSettingsReader(ILogger<JsonSettingsReader<T>> logger, IConfiguration config)
		{
			_logger = logger;
			//_reader = new JsonDataReader<T>(logger); // Behöver förstå mig på data injection
			ConnectionString = config.GetConnectionString("DefaultConnection");
		}

		public T GetDefaultSettings()
		{
			try
			{
				return _reader.ProcessStream(_reader.ConnectSource(ConnectionString));
			}
			catch (Exception ex)
			{
				_logger.LogError($"Error in JsonDataReader : {ex.Message}");
				throw new Exception($"Error, Could not Get DefaultSettings :{ex}");
			}
		}

		public T GetSettings(string id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> GetSettings()
		{
			throw new NotImplementedException();
		}
	}
}
