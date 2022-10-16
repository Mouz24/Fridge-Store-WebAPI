using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IProductsRepository
    {
        IEnumerable<products> GetAllProducts(bool trackChanges);
        void AddProduct(Guid fridgeId, products products);
        void DeleteProduct(products product);
        products GetProduct(Guid Id, bool trackChanges);
        products FindDublicate(ProductsForAddingDTO productstoadd, bool trackChanges);
    }
}
