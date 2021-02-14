using Cofoundry.Core;
using Cofoundry.Domain.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamTree.Cofoundry.Domain.Data
{
    class FamTreeDBContext: DbContext
    {
        private DatabaseSettings _databaseSettings;

        public FamTreeDBContext(DatabaseSettings databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_databaseSettings.ConnectionString);
       
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAppSchema()
                .MapCofoundryContent();
        }

    }
}
