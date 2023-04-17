using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class ProductsInFridgeDTO
    {
        public Guid FridgeId { get; set; }

        public string Product { get; set; }
        
        public int Quantity { get; set; }
    }
}
