using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NGK_G11_Aflv3.Infrastructure;
using NGK_G11_Aflv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGK_G11_Aflv3.Controllers
{
	public class ObservationsController : Controller
	{
		private readonly VejrAppContext context;
        private readonly IWebHostEnvironment webHostEnviroment;

		public ObservationsController(VejrAppContext context, IWebHostEnvironment webHostEnviroment)
		{
			this.context = context;
            this.webHostEnviroment = webHostEnviroment;
		}

		//GET/Observations
		public async Task<IActionResult> Index()
		{
			return View(await context.Observations.OrderByDescending(x => x.ObservationsId).Include(x => x.Location).ToListAsync());
		}

        //Get/Observations/create
        [Authorize]
        public IActionResult Create()
		{
			ViewBag.LocationsId = new SelectList(context.Locations.OrderBy(x => x.Sorting), "ObservationsId", "Name");
			return View();
		}

        //Post/Observations/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Observations Observations)
        {
            ViewBag.LocationId = new SelectList(context.Locations.OrderBy(x => x.Sorting), "Id", "Name");

            if (ModelState.IsValid)
            {
                Observations.Slug = Observations.Name.ToLower().Replace(" ", "-");
              
                var slug = await context.Observations.FirstOrDefaultAsync(x => x.Slug == Observations.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "The Observation already exists. ");
                    return View(Observations);
                }

                context.Add(Observations);
                await context.SaveChangesAsync();

                TempData["Success"] = "The Observation has been added";

                return RedirectToAction("Index");
            }

            return View(Observations);
        }

        // GET/ Observation/details/5
        public async Task<IActionResult> Details(int id)
        {
            Observations Observations = await context.Observations.Include(x => x.Location).FirstOrDefaultAsync(x => x.ObservationsId == id);
            if (Observations == null)
            {
                return NotFound();
            }

            return View(Observations);
        }

        //GET/ Observations/GetLatestTemp/5
        [HttpGet]
        public List<Observations> GetLatestTemp()
        {           
            var LatestData = context.Observations.Take(3).ToList();
            return LatestData;            
        }

        [HttpGet]
        public List<Observations> GetByDate(DateTime date)
        {
			var byDate = context.Observations.Where(x => x.Time.Date == date.Date).ToList();

            return byDate;
        }

        //Get/Observations/GetByInterval/5
        [HttpGet]
        public List<Observations> GetByInterval(DateTime dateStart, DateTime dateend)
        {
			if (dateStart < dateend)
			{
                var byDate = context.Observations.Where(x => x.Time.Date >= dateStart.Date && x.Time.Date <= dateend.Date).ToList();

                return byDate;
            }

            return null; 
        }

        //Get/Observations/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            Observations Observations = await context.Observations.FindAsync(id);
            if (Observations == null)
            {
                TempData["Error"] = "The Observation does not exist!";
            }
            else
            {
                context.Observations.Remove(Observations);
                await context.SaveChangesAsync();
                TempData["Success"] = "The Observation has been deleted";
            }

            return RedirectToAction("Index");
        }
    }
}
