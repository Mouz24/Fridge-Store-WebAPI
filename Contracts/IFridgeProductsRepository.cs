using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IFridgeProductsRepository
    {
        IEnumerable<fridge_products> GetFridgeProducts(bool trackChanges);
        IEnumerable<fridge_products> GetFridge_Products_By_Id(Guid FridgeId, bool trackChanges);
        IEnumerable<ProductsInFridgeDTO> JoinFridgeIdWithProducts(IEnumerable<products> products, IEnumerable<FridgeProductsDTO> fridgeproducts);
        IEnumerable<ProductsInFridgeWithDescriptionDTO> JoinFridgeDescriptionModelsWithProductsInFridge(IEnumerable<FridgeWithModelsDTO> fridgeWithModels,
                                                        IEnumerable<ProductsInFridgeDTO> productsInFridge);
        void PutProductinFridge(Guid FridgeId, fridge_products products, products productsDTO, ProductsForAddingDTO productstoadd);
        void RemoveProductFromFridge(fridge_products product);
        fridge_products GetProductInFridge(Guid FridgeId, Guid Id, bool trackChanges);
        fridge_products GetProductInAllFridges(Guid Id, bool trackChanges);
        bool FridgeProductsDTOIsEmpty(FridgeProductsDTO fridgeProductsDTO);
        bool FridgeDTOIsEmpty(FridgeDTO fridgeProductsDTO);

    }
}
