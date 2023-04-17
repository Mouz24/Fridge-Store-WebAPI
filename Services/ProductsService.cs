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
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productrepository;

        public ProductsService(IProductsRepository productrepository)
        {
            _productrepository = productrepository;
        }

        public void AddProduct(Guid fridgeId, products products)
        {
            _productrepository.AddProduct(fridgeId, products);
        }

        public void DeleteProduct(products product)
        {
            _productrepository.DeleteProduct(product);
        }

        public products FindDublicate(ProductsForAddingDTO productstoadd, bool trackChanges)
        {
            return _productrepository.FindDublicate(productstoadd, trackChanges);
        }

        public IEnumerable<products> GetAllProducts(bool trackChanges)
        {
            return _productrepository.GetAllProducts(trackChanges);
        }

        public products GetProduct(Guid Id, bool trackChanges)
        {
            return _productrepository.GetProduct(Id, trackChanges);
        }
    }
}
