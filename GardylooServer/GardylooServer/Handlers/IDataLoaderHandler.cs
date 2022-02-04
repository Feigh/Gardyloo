using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Handlers
{
	public interface IDataLoaderHandler<T, Strm>
	{
		public Strm ConnectSource(string source);
		public Strm ReadStream(Strm source);
		public T ProcessStream(Strm data);
	}
}
