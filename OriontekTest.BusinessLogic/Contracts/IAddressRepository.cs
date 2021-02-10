using OriontekTest.Dtos.Requests;
using OriontekTest.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OriontekTest.BusinessLogic.Contracts
{
    public interface IAddressRepository
    {
        Task<List<AddressResponse>> GetAddressesAsync(int clientId);
        Task<AddressResponse> SaveAddressAsync(AddressRequest address);
    }
}
