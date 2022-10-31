using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class FridgeWithModelsDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? OwnerName { get; set; }

        public Guid ModelId { get; set; }

        public string NameofModel { get; set; }

        public int? Year { get; set; }
    }
}
