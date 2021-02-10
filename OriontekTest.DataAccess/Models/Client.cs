using System;
using System.Collections.Generic;
using System.Text;

namespace OriontekTest.DataAccess.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModificationDate { get; set; }
        public bool Active { get; set; }

        public List<Address> Addresses { get; set; }
    }
}
