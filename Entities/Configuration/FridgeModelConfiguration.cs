using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Entities.Configuration
{
    public class FridgeModelConfiguration : IEntityTypeConfiguration<fridge_model>
    {
        public void Configure(EntityTypeBuilder<fridge_model> builder)
        {
            builder.HasData(
                new fridge_model
                {
                    Id = new Guid("87d708f9-dcf0-4191-986a-04f01a94eefd"),
                    NameOfModel = "ХМ-6024-031",
                    Year = 2021
                },
                new fridge_model
                {
                    Id = new Guid("7cd3bd81-3d9b-4fa7-8969-24c8008e8eca"),
                    NameOfModel = "ХМ 4209-000",
                    Year = 2020
                }
                );
        }
    }
}
