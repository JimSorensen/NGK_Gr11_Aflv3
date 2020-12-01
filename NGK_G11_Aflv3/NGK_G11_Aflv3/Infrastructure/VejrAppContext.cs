using Microsoft.EntityFrameworkCore;
using NGK_G11_Aflv3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGK_G11_Aflv3.Infrastructure
{
	public class VejrAppContext : DbContext
	{
		public VejrAppContext(DbContextOptions<VejrAppContext> options)
			:base(options)
		{
		}
		public DbSet<Page> Pages { get; set; }		
	}
}
