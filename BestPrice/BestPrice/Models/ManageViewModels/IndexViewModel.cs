using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BestPrice.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        [Display(Name = "Change Email")]
        [EmailAddress]
        public string PendingEmail { get; set; }

        [Display(Name = "Address")]
        public string Location { get; set; }

        public string StatusMessage { get; set; }
    }
}
