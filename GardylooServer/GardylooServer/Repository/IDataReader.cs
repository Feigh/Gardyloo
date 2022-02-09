using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Repository
{
	public interface IDataReader<T> where T : class
	{
		string ConnectionString { get; set; }

		public T GetItem(string id);
		public IEnumerable<T> GetAllItem();
		public T AddItem(T item);
		public T UpdateItem(T item);
		public void DeleteItem(T item);
	}
}
