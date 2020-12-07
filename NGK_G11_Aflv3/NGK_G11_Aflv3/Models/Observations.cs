using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NGK_G11_Aflv3.Models
{
	public class Observations
	{
		public int ObservationsId { get; set; }

		public string Name { get; set; }

		public DateTime Time { get; set; }

		public string Slug { get; set; }

		[Required]
		public float Temperature { get; set; }

		[Required, MinLength(4, ErrorMessage = "Minimum length is 4")]
		public string Description { get; set; }

		public int Humidity { get; set; }

		public float AirPressure { get; set; }

		public int Sorting { get; set; }

		public float Latitude { get; set; }

		public float Longitude { get; set; }

		[ForeignKey("LocationsId")]
		public Locations Location { get; set; }

	}
}
