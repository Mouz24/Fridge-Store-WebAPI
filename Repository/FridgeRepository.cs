using Contracts;
using Entities.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using Entities.DataTransferObjects;

namespace Repository
{
    public class FridgeRepository : RepositoryBase<fridge>, IFridgeRepository
    {
        public FridgeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

        public IEnumerable<fridge> GetAllFridges(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.Name)
        .ToList();

        public IEnumerable<fridge> GetFridgeById(Guid fridgeid, bool trackChanges) => 
        FindByCondition(c => c.Id.Equals(fridgeid), trackChanges);

        public IEnumerable<FridgeWithModelsDTO> JoinFridgeWithModel(IEnumerable<FridgeDTO> fridgeDTO, IEnumerable<fridge_model> fridgemodel)
        {
            var fridgeswithmodels = fridgemodel.Join(fridgeDTO, c => c.Id,
                    p => p.ModelId,
                    (p, c) => new FridgeWithModelsDTO
                    {
                        Id = c.Id,
                        Name = c.Name,
                        OwnerName = c.OwnerName,
                        ModelId = p.Id,
                        NameofModel = p.NameOfModel,
                        Year = p.Year
                    }
                    );

            return fridgeswithmodels;
        }

        public void AddFridge(fridge fridge)
        {
            Create(fridge);
        }

        public void DeleteFridge(fridge fridge)
        {
            Delete(fridge);
        }

        public fridge GetFridge(Guid fridgeid, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(fridgeid), trackChanges).SingleOrDefault();

        public fridge FindDublicateFridgeByName(FridgeForAddingDTO Fridge, bool trackChanges) =>
        FindByCondition(c => c.Name.Equals(Fridge.Name), trackChanges).FirstOrDefault();

        public fridge OtherFridgesOfThisModel(Guid ModelId, bool trackChanges) =>
        FindByCondition(c => c.ModelId.Equals(ModelId), trackChanges).FirstOrDefault();
    }
}
