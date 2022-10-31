using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IProductsService
    {
        IEnumerable<products> GetAllProducts(bool trackChanges);
        void AddProduct(Guid fridgeId, products products);
        void DeleteProduct(products product);
        products GetProduct(Guid Id, bool trackChanges);
        products FindDublicate(ProductsForAddingDTO productstoadd, bool trackChanges);
    }
}
