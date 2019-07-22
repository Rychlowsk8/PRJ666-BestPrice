using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BestPrice.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            getNotified = true;
            saveSearches = true;
        }

        public string Location { get; set; }

        public bool getNotified { get; set; }

        public bool saveSearches { get; set; }
    }
}
