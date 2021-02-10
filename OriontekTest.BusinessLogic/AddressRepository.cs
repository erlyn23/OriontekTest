using OriontekTest.BusinessLogic.Contracts;
using OriontekTest.DataAccess.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using OriontekTest.Dtos.Responses;
using OriontekTest.DataAccess.Models;
using OriontekTest.Dtos.Requests;

namespace OriontekTest.BusinessLogic
{
    public class AddressRepository: IAddressRepository
    {
        private readonly ClientsDbContext _dbContext;
        public AddressRepository(ClientsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AddressResponse>> GetAddressesAsync(int clientId)
        {
            var addresses = await _dbContext.Addresses.Where(address => address.ClientId == clientId).Select(address => 
            new AddressResponse()
            {
                AddressId = address.AddressId,
                City = address.City,
                Country = address.Country,
                PostalCode = address.PostalCode
            }).ToListAsync();

            return addresses;
        }

        public async Task<AddressResponse> SaveAddressAsync(AddressRequest address)
        {
            Address addressEntity = new Address()
            {
                AddressId = address.AddressId,
                City = address.City,
                Country = address.Country,
                PostalCode = address.PostalCode,
                ClientId = address.ClientId,
                CreationDate = DateTime.Today,
            };

            await _dbContext.AddAsync(addressEntity);
            await _dbContext.SaveChangesAsync();

            return new AddressResponse()
            {
                AddressId = addressEntity.AddressId,
                City = addressEntity.City,
                Country = addressEntity.Country,
                PostalCode = addressEntity.PostalCode
            };
        }
    }
}
