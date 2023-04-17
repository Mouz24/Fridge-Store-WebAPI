using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFridgeModelRepository
    {
        void AddModel(fridge_model model);
        void DeleteModel(fridge_model model);
        fridge_model FindDublicateFridge(FridgeForAddingDTO Fridge, bool trackChanges);
        IEnumerable<fridge_model> GetAllFridgeModels(bool trackChanges);
        fridge_model GetModel(Guid id, bool trackChanges);
    }
}
