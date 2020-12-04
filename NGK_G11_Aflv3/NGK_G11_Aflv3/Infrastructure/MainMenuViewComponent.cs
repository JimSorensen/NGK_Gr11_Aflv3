using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGK_G11_Aflv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGK_G11_Aflv3.Infrastructure
{
    public class MainMenuViewComponent : ViewComponent
    {
        private readonly VejrAppContext context;

        public MainMenuViewComponent(VejrAppContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pages = await GetPagesAsync();
            return View(pages);
        }

        private Task<List<Page>> GetPagesAsync()
        {
            return context.Pages.OrderBy(x => x.Sorting).ToListAsync();
        }
    }
}
