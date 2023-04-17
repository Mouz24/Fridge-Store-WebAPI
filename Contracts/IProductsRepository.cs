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
        void AddProduct(Guid fridgeid, products products);
        void DeleteProduct(products product);
        products FindDublicate(ProductsForAddingDTO productstoadd, bool trackChanges);
        IEnumerable<products> GetAllProducts(bool trackChanges);
        products GetProduct(Guid Id, bool trackChanges);
    }
}
