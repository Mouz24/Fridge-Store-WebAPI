using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FridgeProductsService : IFridgeProductsService
    {
        private readonly IFridgeProductsRepository _fridgeproductsrepository;

        public FridgeProductsService(IFridgeProductsRepository fridgeproductsrepository)
        {
            _fridgeproductsrepository = fridgeproductsrepository;
        }

        public bool FridgeDTOIsEmpty(FridgeDTO fridgeProductsDTO)
        {
            return _fridgeproductsrepository.FridgeDTOIsEmpty(fridgeProductsDTO);
        }

        public bool FridgeProductsDTOIsEmpty(FridgeProductsDTO fridgeProductsDTO)
        {
            return _fridgeproductsrepository.FridgeProductsDTOIsEmpty(fridgeProductsDTO);
        }

        public IEnumerable<fridge_products> GetFridgeProducts(bool trackChanges)
        {
            return _fridgeproductsrepository.GetFridgeProducts(trackChanges);
        }

        public IEnumerable<fridge_products> GetFridge_Products_By_Id(Guid FridgeId, bool trackChanges)
        {
            return _fridgeproductsrepository.GetFridge_Products_By_Id(FridgeId, trackChanges);
        }

        public fridge_products GetProductInAllFridges(Guid Id, bool trackChanges)
        {
            return _fridgeproductsrepository.GetProductInAllFridges(Id, trackChanges);
        }

        public fridge_products GetProductInFridge(Guid FridgeId, Guid Id, bool trackChanges)
        {
            return _fridgeproductsrepository.GetProductInFridge(FridgeId, Id, trackChanges);
        }

        public IEnumerable<ProductsInFridgeWithDescriptionDTO> JoinFridgeDescriptionModelsWithProductsInFridge(IEnumerable<FridgeWithModelsDTO> fridgeWithModels, IEnumerable<ProductsInFridgeDTO> productsInFridge)
        {
            return _fridgeproductsrepository.JoinFridgeDescriptionModelsWithProductsInFridge(fridgeWithModels, productsInFridge);
        }

        public IEnumerable<ProductsInFridgeDTO> JoinFridgeIdWithProducts(IEnumerable<products> products, IEnumerable<FridgeProductsDTO> fridgeproducts)
        {
            return _fridgeproductsrepository.JoinFridgeIdWithProducts(products, fridgeproducts);
        }

        public void PutProductinFridge(Guid FridgeId, fridge_products products, products productsDTO, ProductsForAddingDTO productstoadd)
        {
            _fridgeproductsrepository.PutProductinFridge(FridgeId, products, productsDTO, productstoadd);
        }

        public void RemoveProductFromFridge(fridge_products product)
        {
            _fridgeproductsrepository.RemoveProductFromFridge(product);
        }
    }
}
