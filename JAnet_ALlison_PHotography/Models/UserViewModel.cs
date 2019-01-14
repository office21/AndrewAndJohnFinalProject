using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JAnet_ALlison_PHotography.Models
{
    public class UserViewModel
    {
        public UserViewModel() { }

        public UserViewModel(ApplicationRole role, ApplicationUser user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            RoleName = role.Name;
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }

    }
}