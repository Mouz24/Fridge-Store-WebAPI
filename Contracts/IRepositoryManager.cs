using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IFridgeRepository Fridge{ get; }
        IFridgeProductsRepository Fridge_Products { get; }
        IFridgeModelRepository Model { get; }
        IProductsRepository Products { get; }
        void Save();
        Task SaveAsync();
    }
}
