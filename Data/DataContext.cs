using SistemaMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaWebProd.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Fornecedor> Fornecedors { get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}