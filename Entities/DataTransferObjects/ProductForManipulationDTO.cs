using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract class ProductForManipulationDTO
    {
        [Required(ErrorMessage = "Product name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Product { get; set; }

        [Required(ErrorMessage = "Quantity is a required field.")]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity is required and can't be less than 0")]
        public int Quantity { get; set; }

        public int? DefaultQuantity { get; set; }
    }
}
