using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ProductsInFridgeWithDescriptionDTO
    {
        public Guid Fridge_Id { get; set; }

        public string Name { get; set; }

        public string? OwnerName { get; set; }

        public string NameofModel { get; set; }
        
        public int? Year { get; set; }

        public string Product { get; set; }

        public int Quantity { get; set; }

    }
}
