using Microsoft.EntityFrameworkCore;
using OriontekTest.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OriontekTest.DataAccess.DbContexts
{
    public class ClientsDbContext: DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public ClientsDbContext(DbContextOptions<ClientsDbContext> options): base(options)
        {

        }
    }
}
