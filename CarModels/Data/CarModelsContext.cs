using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarModels.Models;

namespace CarModels.Data
{
    public class CarModelsContext : DbContext
    {
        public CarModelsContext (DbContextOptions<CarModelsContext> options)
            : base(options)
        {
        }

        public DbSet<CarModels.Models.CarModelsLogic> CarModelsLogics { get; set; }
    }
}
