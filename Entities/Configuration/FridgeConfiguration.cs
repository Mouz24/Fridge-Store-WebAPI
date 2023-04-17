using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class FridgeConfiguration : IEntityTypeConfiguration<fridge>
    {
        public void Configure(EntityTypeBuilder<fridge> builder)
        {
            builder.HasData(
                new fridge
                {
                    Id = new Guid("4fb88ac7-616b-4763-aa44-76523d9a6051"),
                    Name = "Atlant",
                    OwnerName = "Maxim",
                    ModelId = new Guid("87d708f9-dcf0-4191-986a-04f01a94eefd")
                },
                new fridge
                {
                    Id = new Guid("36b5e304-6b86-4097-9af6-3fe7792b02e1"),
                    Name = "Atlant",
                    OwnerName = "Alexandr",
                    ModelId = new Guid("7cd3bd81-3d9b-4fa7-8969-24c8008e8eca")
                }
                );
        }
    }
}
