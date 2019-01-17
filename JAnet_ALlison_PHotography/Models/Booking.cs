using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace JAnet_ALlison_PHotography.Models
{
    public class Booking
    {
        [Key]
        public int booking_Id { get; set; }

        [Display(Name = "Employee: ")]
        [Required(ErrorMessage = "Your {0} is required")]
        public string employee_Id { get; set; }

        [Display(Name = "Customer Email: ")]
        public string UserName { get; set; }

        [Display(Name = "Date: ")]
        [Required(ErrorMessage = "Your {0} is required")]
        [DataType(DataType.Date)]
        public DateTime dateTime { set; get; }

        [Required(ErrorMessage = "Your {0} is required")]
        [Display(Name = "Photo Detail: ")]
        public string PhotoDetail { get; set; }

        [Required(ErrorMessage = "Your {0} is required")]
        [Display(Name = "Photoshoot Type: ")]
        public PhotoType PhotoType{get; set;}

        [Display(Name = "Amount of People/Pet : ")]
        [Range(1, 1000, ErrorMessage = "Please Enter A Proper Amount Of People/Pet (1 to 1000)")]
        [Required(ErrorMessage = "Your {0} is required")]
        public int Quantity { set; get; }

    }
    public enum PhotoType
    {
        Pet,
        Portrait,
        Event,
        Weddings,
    }

}