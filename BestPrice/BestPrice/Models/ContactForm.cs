using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Org.BouncyCastle.Ocsp;

namespace BestPrice.Models
{
    public class ContactForm
    {
        [MaxLength(65, ErrorMessage = "Maximum length of this field is 65")]
        [Required]
        public string Subject { get; set; }

        [MaxLength(25, ErrorMessage = "Maximum length of this field is 25")]
        [Required]
        public string Name { get; set; }

        [MaxLength(254, ErrorMessage = "Maximum length of this field is 254")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [MaxLength(2000, ErrorMessage = "Maximum length of this field is 2000")]
        [Required]
        public string Message { get; set; }
    }
}
