using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OriontekTest.Dtos.Requests
{
    public class AddressRequest
    {
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(3, ErrorMessage = "Este campo acepta 3 carácteres mínimo")]
        [MaxLength(30, ErrorMessage = "Este campo acepta 30 carácteres máximo")]
        public string City { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(3, ErrorMessage = "Este campo acepta 3 carácteres mínimo")]
        [MaxLength(30, ErrorMessage = "Este campo acepta 30 carácteres máximo")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(3, ErrorMessage = "Este campo acepta 3 carácteres mínimo")]
        [MaxLength(30, ErrorMessage = "Este campo acepta 30 carácteres máximo")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int ClientId { get; set; }
    }
}
