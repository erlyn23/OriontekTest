using System;
using System.Collections.Generic;
using System.Text;

namespace OriontekTest.Dtos.Responses
{
    public class AddressResponse
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
