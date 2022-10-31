using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<products>
    {
       public void Configure(EntityTypeBuilder<products> builder)
       {
            builder.HasData(
                
                new products
                {
                    Id = new Guid("2c7e4b08-4ffa-4c65-93d7-68b9f8ea4ddc"),
                    Product = "Cheese",
                    DefaultQuantity = 2
                },
                new products
                {
                    Id = new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"),
                    Product = "Sausage",
                    DefaultQuantity = 7 
                },
                new products
                {
                    Id = new Guid("e52efc08-e592-4f81-a0b5-b570a7604b09"),
                    Product = "Tomatoe",
                    DefaultQuantity = 4
                },
                new products
                {
                    Id = new Guid("2a0f7338-06b6-4ed6-8583-d68aa4929263"),
                    Product = "Cucumber",
                    DefaultQuantity = 3
                },
                new products
                {
                    Id = new Guid("62fcb049-40df-409e-a39a-60b4942dbb09"),
                    Product = "Egg",
                    DefaultQuantity = 10
                },
                new products
                {
                    Id = new Guid("472f1ef6-7902-43c0-ba83-ed520d0cd0f2"),
                    Product = "Beef",
                    DefaultQuantity = 2
                }
                );
       }
    }
}
