using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_webAPI.Domains
{
    public class AluguelDomain
    {
        public int idAluguel { get; set; }
        public int idVeiculo { get; set; }
        public int idCliente { get; set; }
        public VeiculoDomain Veiculo { get; set; }
        public ClienteDomain Cliente { get; set; }
        public DateTime dataAluguel { get; set; }
    }
}
