using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Domains
{
    public class ModeloDomain
    {
        public int idModelo { get; set; }
        public MarcaDomain idMarca { get; set; }
        public string nomeModelo { get; set; }
        public DateTime anoModelo { get; set; }
    }
}
