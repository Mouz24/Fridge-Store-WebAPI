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
    public class FridgeProductsConfiguration : IEntityTypeConfiguration<fridge_products>
    {
       public void Configure(EntityTypeBuilder<fridge_products> builder)
        {
            builder.HasData(
                new fridge_products
                {
                    Id = new Guid("1117aee8-cfc5-4a7d-85bd-3b869b334a21"),
                    ProductId = new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"),
                    FridgeId = new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"),
                    Quantity = 6
                },
                new fridge_products
                {
                    Id = new Guid("36e8b9dd-cbfa-4ac3-9273-b20ebeb226b5"),
                    ProductId = new Guid("2a0f7338-06b6-4ed6-8583-d68aa4929263"),
                    FridgeId = new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"),
                    Quantity = 4
                },
                new fridge_products
                {
                    Id = new Guid("1e0c50ea-8503-4b85-b86a-92077130249c"),
                    ProductId = new Guid("62fcb049-40df-409e-a39a-60b4942dbb09"),
                    FridgeId = new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"),
                    Quantity = 7
                },
                new fridge_products
                {
                    Id = new Guid("d99726a5-b08a-4ace-adfc-eec6c2c60f8d"),
                    ProductId = new Guid("d5605993-f8e9-4a04-bd17-00405cc9c9c0"),
                    FridgeId = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"),
                    Quantity = 4
                },
                new fridge_products
                {
                    Id = new Guid("a7b6eaf4-7a70-482a-8a0a-1240ef0c3a63"),
                    ProductId = new Guid("472f1ef6-7902-43c0-ba83-ed520d0cd0f2"),
                    FridgeId = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"),
                    Quantity = 0
                },
                new fridge_products
                {
                    Id = new Guid("ae9042f1-379d-43eb-b7d3-57250f59c0a1"),
                    ProductId = new Guid("2c7e4b08-4ffa-4c65-93d7-68b9f8ea4ddc"),
                    FridgeId = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"),
                    Quantity = 1
                }
                );
        }
    }
}
