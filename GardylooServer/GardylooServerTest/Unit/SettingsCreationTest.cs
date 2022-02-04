using GardylooServer.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GardylooServerTest.Unit
{
	public class SettingsCreationTest
	{
		private readonly SettingsHandler _sut;

		public SettingsCreationTest()
		{
			_sut = new SettingsHandler();
		}
	}
}
