using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BestPrice.Models
{
    public class Problem
    {
        [MaxLength(65)]
        [Required]
        public string Subject { get; set; }

        [MaxLength(1500)]
        [Required]
        public string Description { get; set; }
    }
}
