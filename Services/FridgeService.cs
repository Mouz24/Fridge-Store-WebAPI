using Contracts;
using Entities.Context;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FridgeService : IFridgeService
    {
        private readonly IFridgeRepository _fridgerepository;

        private readonly DapperContext _context;

        public FridgeService(IFridgeRepository fridgerepository, DapperContext context)
        {
            _fridgerepository = fridgerepository;
            _context = context;
        }

        public void AddFridge(fridge fridge)
        {
            _fridgerepository.AddFridge(fridge);
        }

        public void DeleteFridge(fridge fridge)
        {
            _fridgerepository.DeleteFridge(fridge);
        }

        public fridge FindDublicateFridgeByName(FridgeForAddingDTO Fridge, bool trackChanges)
        {
            return _fridgerepository.FindDublicateFridgeByName(Fridge, trackChanges);
        }

        public IEnumerable<fridge> GetAllFridges(bool trackChanges)
        {
            return _fridgerepository.GetAllFridges(trackChanges);
        }

        public fridge GetFridge(Guid fridgeid, bool trackChanges)
        {
            return _fridgerepository.GetFridge(fridgeid, trackChanges);
        }

        public IEnumerable<fridge> GetFridgeById(Guid fridgeid, bool trackChanges)
        {
            return _fridgerepository.GetFridgeById(fridgeid, trackChanges);
        }

        public Task<IEnumerable<fridge_products>> ImplementStoredProcedureAsync()
        {
            return _fridgerepository.ImplementStoredProcedureAsync();
        }

        public IEnumerable<FridgeWithModelsDTO> JoinFridgeWithModel(IEnumerable<FridgeDTO> fridgeDTO, IEnumerable<fridge_model> fridgemodel)
        {
            return _fridgerepository.JoinFridgeWithModel(fridgeDTO, fridgemodel);
        }

        public fridge OtherFridgesOfThisModel(Guid ModelId, bool trackChanges)
        {
            return _fridgerepository.OtherFridgesOfThisModel(ModelId, trackChanges);
        }
    }
}
