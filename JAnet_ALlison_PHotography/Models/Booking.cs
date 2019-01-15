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

        [Display(Name = "Time: ")]
        [Required(ErrorMessage = "Your {0} is required")]
        public int TimeSlot { get; set; }

        [Required(ErrorMessage = "Your {0} is required")]
        [Display(Name = "Photo Detail: ")]
        public string PhotoDetail { get; set; }



    }
    
}