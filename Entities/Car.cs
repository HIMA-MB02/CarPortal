using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VahanBlog.Entities
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required(ErrorMessage = "Please enter a Make")]
        public string Make { get; set; }

        [Required(ErrorMessage = "Please enter a Price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a Model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please enter a Fuel Type")]
        public string FuelType { get; set; }

        [Required(ErrorMessage = "Please enter a Transmission Type")]
        public string TransmissionType { get; set; }

        [Required(ErrorMessage = "Please enter the number of Owners")]
        public string Owners { get; set; }
        
        [Required(ErrorMessage = "Please enter the number of Kilometers on the Car")]
        public string Kilometers { get; set; }

        public string Year { get; set; }

        public virtual IList<Images> Images { get; set; }
    }
}