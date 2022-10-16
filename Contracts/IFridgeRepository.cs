using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Entities;
using Entities.Models;
using Entities.DataTransferObjects;

namespace Contracts
{
    public interface IFridgeRepository
    {
        IEnumerable<fridge> GetAllFridges(bool trackChanges);
        IEnumerable<fridge> GetFridgeById(Guid fridgeid, bool trackChanges);
        IEnumerable<FridgeWithModelsDTO> JoinFridgeWithModel(IEnumerable<FridgeDTO> fridgeDTO, IEnumerable<fridge_model> fridgemodel);
        fridge FindDublicateFridgeByName(FridgeForAddingDTO Fridge, bool trackChanges);
        fridge OtherFridgesOfThisModel(Guid ModelId, bool trackChanges);
        fridge GetFridge(Guid fridgeid, bool trackChanges);
        void AddFridge(fridge fridge);
        void DeleteFridge(fridge fridge);

    }
}
