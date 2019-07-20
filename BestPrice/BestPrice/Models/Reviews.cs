using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BestPrice.Models
{
    public partial class Reviews
    {
        public int Id { get; set; }
        [MaxLength(65, ErrorMessage = "Maximum length of this field is 65")]
        [Required]
        public string Subject { get; set; }
        [MaxLength(1500, ErrorMessage = "Maximum length of this field is 1500")]
        [Required]
        public string Description { get; set; }
        public int? Rating { get; set; }
        public string ProductName { get; set; }
        public string SellerName { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCondition { get; set; }
        public float? Price { get; set; }
        public short SoldOut { get; set; }
    }
}
