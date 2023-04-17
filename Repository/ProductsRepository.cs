using Contracts;
using Entities.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataTransferObjects;

namespace Repository
{
    public class ProductsRepository : RepositoryBase<products>, IProductsRepository
    {
        public ProductsRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

        public void AddProduct(Guid fridgeid, products products)
        {
            Create(products);
        }

        public void DeleteProduct(products product)
        {
            Delete(product);
        }

        public products FindDublicate(ProductsForAddingDTO productstoadd, bool trackChanges) =>
        FindByCondition(e => e.Product.Equals(productstoadd.Product), trackChanges).FirstOrDefault();
        
        public IEnumerable<products> GetAllProducts(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(c => c.Product)
        .ToList();

        public products GetProduct(Guid Id, bool trackChanges) =>
        FindByCondition(e => e.Id.Equals(Id), trackChanges).FirstOrDefault();
    }
}
