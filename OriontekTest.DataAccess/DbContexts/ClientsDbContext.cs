using Microsoft.EntityFrameworkCore;
using OriontekTest.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OriontekTest.DataAccess.DbContexts
{
    public class ClientsDbContext: DbContext
    {
        private readonly DbContextOptions _options;

        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public ClientsDbContext(DbContextOptions options): base(options)
        {

        }
    }
}
