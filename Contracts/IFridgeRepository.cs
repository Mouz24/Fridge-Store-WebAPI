using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFridgeRepository
    {
        IEnumerable<fridge> GetAllFridges(bool trackChanges);
        IEnumerable<fridge> GetFridgeById(Guid fridgeid, bool trackChanges);
        IEnumerable<FridgeWithModelsDTO> JoinFridgeWithModel(IEnumerable<FridgeDTO> fridgeDTO, IEnumerable<fridge_model> fridgemodel);
        void AddFridge(fridge fridge);
        void DeleteFridge(fridge fridge);
        fridge GetFridge(Guid fridgeid, bool trackChanges);
        fridge FindDublicateFridgeByName(FridgeForAddingDTO Fridge, bool trackChanges);
        fridge OtherFridgesOfThisModel(Guid ModelId, bool trackChanges);
        Task<IEnumerable<fridge_products>> ImplementStoredProcedureAsync();

    }
}
