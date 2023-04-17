using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class FridgeForUpdateDTO
    {
        [Required(ErrorMessage = "Product name is a required field.")]
        public string Name { get; set; }

        public string? OwnerName { get; set; }

        [Required(ErrorMessage = "Product name is a required field.")]
        public string NameOfModel { get; set; }

        public int? Year { get; set; }
    }
}
