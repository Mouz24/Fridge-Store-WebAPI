using Contracts;
using Entities;
using Entities.Context;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IRepositoryManager _repositoryManager;
        private IFridgeModelService _FridgeModelService;
        private IFridgeProductsService _FridgeProductsService;
        private IFridgeService _FridgeService;
        private IProductsService _ProductsService;
        private readonly DapperContext _dapperContext;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IFridgeService Fridge
        {
            get
            {
                if (_FridgeService == null)
                {
                    _FridgeService = new FridgeService(_repositoryManager.Fridge, _dapperContext);
                }

                return _FridgeService;
            }
        }

        public IFridgeProductsService Fridge_Products
        {
            get
            {
                if (_FridgeProductsService == null)
                    _FridgeProductsService = new FridgeProductsService(_repositoryManager.Fridge_Products);
                return _FridgeProductsService;
            }
        }

        public IFridgeModelService Model
        {
            get
            {
                if (_FridgeModelService == null)
                    _FridgeModelService = new FridgeModelService(_repositoryManager.Model);
                return _FridgeModelService;
            }
        }

        public IProductsService Products
        {
            get
            {
                if (_ProductsService == null)
                    _ProductsService = new ProductsService(_repositoryManager.Products);
                return _ProductsService;
            }
        }

        public void Save()
        {
            _repositoryManager.Save();
        }

        public async Task SaveAsync()
        {
            await _repositoryManager.SaveAsync();
        }
    }
}
