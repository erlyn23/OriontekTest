using OriontekTest.Dtos.Requests;
using OriontekTest.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OriontekTest.BusinessLogic.Contracts
{
    public interface IClientRepository
    {
        Task<List<ClientResponse>> GetClientsAsync();
        Task<ClientResponse> SaveOrUpdateClientAsync(ClientRequest client);
        Task<ClientResponse> DeleteClientAsync(int clientId);
    }
}
