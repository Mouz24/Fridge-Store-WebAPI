using Contracts;
using Entities.Models;
using Entities;
using Entities.DataTransferObjects;
using System.Data;

namespace Repository
{
    public class FridgeProductsRepository : RepositoryBase<fridge_products>, IFridgeProductsRepository
    {
        public FridgeProductsRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

        public IEnumerable<fridge_products> GetFridgeProducts(bool trackChanges) =>
         FindAll(trackChanges)
        .ToList();

        public IEnumerable<fridge_products>  GetFridge_Products_By_Id(Guid FridgeId, bool trackChanges) =>
        FindByCondition(c => c.FridgeId.Equals(FridgeId), trackChanges);

        public IEnumerable<ProductsInFridgeDTO> JoinFridgeIdWithProducts(IEnumerable<products> products, IEnumerable<FridgeProductsDTO> fridgeproducts)
        {
            var products_in_fridge = products.Join(fridgeproducts, c => c.Id, p => p.ProductId,
                (c, p) => new ProductsInFridgeDTO
                {
                    FridgeId = p.FridgeId,
                    Product = c.Product,
                    Quantity = p.Quantity,
                }
            );

            return products_in_fridge;
        }

        public IEnumerable<ProductsInFridgeWithDescriptionDTO> JoinFridgeDescriptionModelsWithProductsInFridge(
               IEnumerable<FridgeWithModelsDTO> fridgeWithModels, 
               IEnumerable<ProductsInFridgeDTO> productsInFridge)
        {
            var products_in_fridge_with_fridge_description = productsInFridge.Join(fridgeWithModels,
                c => c.FridgeId, p => p.Id,
                (c, p) => new ProductsInFridgeWithDescriptionDTO
                {
                    Fridge_Id = c.FridgeId,
                    Name = p.Name,
                    OwnerName = p.OwnerName,
                    NameofModel = p.NameofModel,
                    Year = p.Year,
                    Product = c.Product,
                    Quantity = c.Quantity
                }
                );

            return products_in_fridge_with_fridge_description;
        }

        public void PutProductinFridge(Guid FridgeId, fridge_products products, products productsDTO, ProductsForAddingDTO productstoadd)
        {
            products.FridgeId = FridgeId;
            products.ProductId = productsDTO.Id;
            products.Quantity = productstoadd.Quantity;

            Create(products);
        }

        public void RemoveProductFromFridge(fridge_products product)
        {
            Delete(product);
        }

        public fridge_products GetProductInFridge(Guid FridgeId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.FridgeId.Equals(FridgeId) && e.ProductId.Equals(Id),trackChanges).SingleOrDefault();

        public fridge_products GetProductInAllFridges(Guid Id, bool trackChanges) =>
            FindByCondition(e => e.ProductId.Equals(Id), trackChanges).FirstOrDefault();

        public bool FridgeProductsDTOIsEmpty(FridgeProductsDTO fridgeProductsDTO)
        {
            if (fridgeProductsDTO.Id == new Guid("00000000-0000-0000-0000-000000000000") && 
                fridgeProductsDTO.FridgeId == new Guid("00000000-0000-0000-0000-000000000000") &&
                fridgeProductsDTO.ProductId == new Guid("00000000-0000-0000-0000-000000000000") &&
                fridgeProductsDTO.Quantity == 0)
            {
                return true;
            }

            return false;
        }

        public bool FridgeDTOIsEmpty(FridgeDTO fridgeDTO)
        {
            if (fridgeDTO.Id == new Guid("00000000-0000-0000-0000-000000000000") &&
                fridgeDTO.ModelId == new Guid("00000000-0000-0000-0000-000000000000") &&
                fridgeDTO.OwnerName == null &&
                fridgeDTO.Name == null)
            {
                return true;
            }

            return false;
        }
    }
}
