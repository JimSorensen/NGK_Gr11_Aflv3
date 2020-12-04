using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGK_G11_Aflv3.Infrastructure;
using NGK_G11_Aflv3.Models;

namespace NGK_G11_Aflv3.Controllers
{
    public class PagesController : Controller
    {
        private readonly VejrAppContext context;

        public PagesController(VejrAppContext context)
        {
            this.context = context;
        }

        //GET / or /slug
        public async Task<IActionResult> Page(string slug)
        {
            if (slug == null)
            {
                return View(await context.Pages.Where(x => x.Slug == "home").FirstOrDefaultAsync());
            }

            Page page = await context.Pages.Where(x => x.Slug == slug).FirstOrDefaultAsync();

            if(page == null)
            {
                return NotFound();
            }
            return View(page);
        }
    }
}
