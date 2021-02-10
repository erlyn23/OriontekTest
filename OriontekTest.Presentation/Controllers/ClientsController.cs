using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OriontekTest.BusinessLogic.Contracts;
using OriontekTest.Dtos.Requests;
using OriontekTest.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriontekTest.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientResponse>>> GetClientsAsync()
        {
            try
            {
                var clients = await _clientRepository.GetClientsAsync();
                return Ok(clients);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "SaveClient")]
        public async Task<ActionResult<ClientResponse>> SaveClientAsync(ClientRequest client)
        {
            try
            {
                var clientSaved = await _clientRepository.SaveOrUpdateClientAsync(client);
                return CreatedAtRoute("SaveClient", new { id = client.ClientId }, clientSaved);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ClientResponse>> UpdateClientAsync(ClientRequest client)
        {
            try
            {
                var clientModified = await _clientRepository.SaveOrUpdateClientAsync(client);
                return Ok(clientModified);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{clientId}")]
        public async Task<ActionResult<ClientResponse>> DeleteClientAsync(int clientId)
        {
            try
            {
                var clientDeleted = await _clientRepository.DeleteClientAsync(clientId);
                return Ok(clientDeleted);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
    }
}
