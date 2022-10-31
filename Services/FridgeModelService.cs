using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Services.IServices;

namespace Services
{
    public class FridgeModelService : IFridgeModelService
    {
        private readonly IFridgeModelRepository _fridgemodelrepository;

        public FridgeModelService(IFridgeModelRepository fridgemodelrepository)
        {
            _fridgemodelrepository = fridgemodelrepository;
        }

        public void AddModel(fridge_model model)
        {
             _fridgemodelrepository.AddModel(model);
        }

        public void DeleteModel(fridge_model model)
        {
            _fridgemodelrepository.DeleteModel(model);
        }

        public fridge_model FindDublicateFridge(FridgeForAddingDTO Fridge, bool trackChanges)
        {
            return _fridgemodelrepository.FindDublicateFridge(Fridge, trackChanges);
        }

        public IEnumerable<fridge_model> GetAllFridgeModels(bool trackChanges)
        {
            return _fridgemodelrepository.GetAllFridgeModels(trackChanges);
        }

        public fridge_model GetModel(Guid id, bool trackChanges)
        {
            return _fridgemodelrepository.GetModel(id, trackChanges);
        }
    }
}