using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Repository
{
	public class JsonDataReader<T> : IDataReader<T>
	{
		public T AddItem(T item)
		{
			throw new NotImplementedException();
		}

		public void DeleteItem(T item)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<T> GetAllItem()
		{
			throw new NotImplementedException();
		}

		public T GetItem(string id)
		{
			throw new NotImplementedException();
		}

		public T UpdateItem(T item)
		{
			throw new NotImplementedException();
		}
	}
}
