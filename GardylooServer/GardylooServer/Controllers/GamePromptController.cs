using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardylooServer.Controllers
{
	public class GamePromptController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
