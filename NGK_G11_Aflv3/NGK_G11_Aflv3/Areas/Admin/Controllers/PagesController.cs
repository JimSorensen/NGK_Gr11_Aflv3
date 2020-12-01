using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGK_G11_Aflv3.Infrastructure;
using NGK_G11_Aflv3.Models;

namespace NGK_G11_Aflv3.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PagesController : Controller
	{
		private readonly VejrAppContext context;

		public PagesController(VejrAppContext context)
		{
			this.context = context;
		}

	}
}
