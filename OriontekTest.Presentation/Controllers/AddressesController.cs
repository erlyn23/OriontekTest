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
    public class AddressesController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;
        public AddressesController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet("{clientId}")]
        public async Task<ActionResult<List<AddressResponse>>> GetAddressessAsync(int clientId)
        {
            try
            {
                var addresses = await _addressRepository.GetAddressesAsync(clientId);
                return Ok(addresses);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost(Name = "SaveAddress")]
        public async Task<ActionResult<AddressResponse>> SaveAddressAsync(AddressRequest address)
        {
            try
            {
                var addressSaved = await _addressRepository.SaveAddressAsync(address);
                return CreatedAtRoute("SaveAddress", new { id = address.AddressId }, address);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
