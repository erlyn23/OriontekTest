using System;
using System.Collections.Generic;
using System.Text;

namespace OriontekTest.DataAccess.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public int ClientId { get; set; }
        public DateTime CreationDate { get; set; }

        public Client Client { get; set; }
    }
}
