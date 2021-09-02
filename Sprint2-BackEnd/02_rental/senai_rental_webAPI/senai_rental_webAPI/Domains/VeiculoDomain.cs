using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Domains
{
    public class VeiculoDomain
    {
        public int idVeiculo { get; set; }
        public ModeloDomain idModelo { get; set; }
        public EmpresaDomain idEmpresa { get; set; }
        public string placa { get; set; }
    }
}
