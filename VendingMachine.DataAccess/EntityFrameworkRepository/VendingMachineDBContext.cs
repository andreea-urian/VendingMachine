using iQuest.VendingMachine.DataAccess.Domaine;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.DataAccess.EntityFrameworkRepository
{
    public class VendingMachineDBContext:DbContext
    {
        private readonly string ConnectionString = @"Data Source=.\EFVendingMachineDb.db;";
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sale { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }
    }
}
