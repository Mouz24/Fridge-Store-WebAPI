using Contracts;
using Entities;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FridgeModelRepository : RepositoryBase<fridge_model>, IFridgeModelRepository
    {
        public FridgeModelRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

        public void AddModel(fridge_model model)
        {
            Create(model);
        }

        public void DeleteModel(fridge_model model)
        {
            Delete(model);  
        }

        public fridge_model FindDublicateFridge(FridgeForAddingDTO Fridge, bool trackChanges) =>
        FindByCondition(c => c.NameOfModel.Equals(Fridge.NameOfModel) && c.Year.Equals(Fridge.Year), trackChanges).FirstOrDefault();

        public IEnumerable<fridge_model> GetAllFridgeModels(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.NameOfModel)
        .ToList();

        public fridge_model GetModel(Guid id, bool trackChanges) =>
        FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();
    }
}
