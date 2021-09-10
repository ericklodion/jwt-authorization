using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErickEspinosa.WebApiAspNetCore.JWToken.Models
{
    public class Product
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
