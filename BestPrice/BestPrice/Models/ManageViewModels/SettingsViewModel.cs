using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BestPrice.Models.ManageViewModels
{
    public class SettingsViewModel : IndexViewModel
    {
        public SettingsViewModel()
        {
            getNotified = true;
            saveSearches = true;
        }

        [Display(Name = "Receive notifications")]
        public bool getNotified { get; set; }

        [Display(Name = "Save recent searches")]
        public bool saveSearches { get; set; }
    }
}
