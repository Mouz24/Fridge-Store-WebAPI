using Contracts;
using Entities;
using Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;

        private DapperContext _dapperContext;

        private IFridgeRepository _FridgeRepository;

        private IFridgeProductsRepository _Fridge_ProductsRepository;

        private IFridgeModelRepository _ModelRepository;

        private IProductsRepository _ProductsRepository;

        public RepositoryManager(RepositoryContext repositoryContext, DapperContext dapperContext)
        {
            _repositoryContext = repositoryContext;
            _dapperContext = dapperContext;
        }

        public IFridgeRepository Fridge
        {
            get
            {
                if (_FridgeRepository == null)
                    _FridgeRepository = new FridgeRepository(_repositoryContext, _dapperContext);
                return _FridgeRepository;
            }
        }

        public IFridgeProductsRepository Fridge_Products
        {
            get
            {
                if (_Fridge_ProductsRepository == null)
                    _Fridge_ProductsRepository = new FridgeProductsRepository(_repositoryContext);
                return _Fridge_ProductsRepository;
            }
        }

        public IFridgeModelRepository Model
        {
            get
            {
                if (_ModelRepository == null)
                    _ModelRepository = new FridgeModelRepository(_repositoryContext);
                return _ModelRepository;
            }
        }

        public IProductsRepository Products
        {
            get
            {
                if (_ProductsRepository == null)
                    _ProductsRepository = new ProductsRepository(_repositoryContext);
                return _ProductsRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
