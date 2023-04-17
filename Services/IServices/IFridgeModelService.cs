using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IFridgeModelService
    {
        IEnumerable<fridge_model> GetAllFridgeModels(bool trackChanges);
        void AddModel(fridge_model model);
        void DeleteModel(fridge_model model);
        fridge_model GetModel(Guid id, bool trackChanges);
        fridge_model FindDublicateFridge(FridgeForAddingDTO Fridge, bool trackChanges);
    }
}
