using OriontekTest.BusinessLogic.Contracts;
using OriontekTest.DataAccess.DbContexts;
using OriontekTest.Dtos.Requests;
using OriontekTest.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OriontekTest.DataAccess.Models;

namespace OriontekTest.BusinessLogic
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientsDbContext _dbContext;
        public ClientRepository(ClientsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ClientResponse>> GetClientsAsync()
        {
            var clients = await _dbContext.Clients.Where(client => client.Active).Select(client => new ClientResponse()
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName
            }).ToListAsync();

            return clients;
        }
        public async Task<ClientResponse> SaveOrUpdateClientAsync(ClientRequest client)
        {
            Client clientEntity = new Client()
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                CreationDate = DateTime.Today,
                LastModificationDate = DateTime.Today,
                Active = true
            };

            if (clientEntity.ClientId > 0)
                _dbContext.Clients.Update(clientEntity);
            else
                await _dbContext.Clients.AddAsync(clientEntity);

            await _dbContext.SaveChangesAsync();

            return new ClientResponse() 
            {
                ClientId = clientEntity.ClientId, 
                FirstName = clientEntity.FirstName, 
                LastName = clientEntity.LastName 
            };
        }
        public async Task<ClientResponse> DeleteClientAsync(int clientId)
        {
            var client = await _dbContext.Clients.Where(client => client.ClientId == clientId && client.Active)
                               .FirstOrDefaultAsync();

            if (client != null)
                _dbContext.Clients.Remove(client);
            
            await _dbContext.SaveChangesAsync();

            return new ClientResponse() 
            { 
                ClientId = client.ClientId,
                FirstName = client.FirstName, 
                LastName = client.LastName 
            };
        }
    }
}
