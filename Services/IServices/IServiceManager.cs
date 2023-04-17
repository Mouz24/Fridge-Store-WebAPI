using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IServiceManager
    {
        IFridgeService Fridge { get; }
        IFridgeProductsService Fridge_Products { get; }
        IFridgeModelService Model { get; }
        IProductsService Products { get; }
        void Save();
        Task SaveAsync();
    }
}
