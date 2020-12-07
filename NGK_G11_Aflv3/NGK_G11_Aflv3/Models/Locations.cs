using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NGK_G11_Aflv3.Models
{
	public class Locations
	{
        [Key]
        public int LocationsId { get; set; }

        [Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string Name { get; set; }

        

        public int Sorting { get; set; }

        //relations
        public List<Observations> Observations { get; set; }
    }
}
