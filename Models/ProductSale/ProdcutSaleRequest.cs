using System;
using System.ComponentModel.DataAnnotations;

namespace pruebaAPI.Models
{
    public class ProductSaleRequest
    {
        [Required(ErrorMessage = "Product is required")]
        public Guid? Product { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
    }
}