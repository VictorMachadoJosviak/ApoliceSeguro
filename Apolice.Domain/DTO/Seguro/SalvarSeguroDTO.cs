using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolice.Domain.DTO.Seguro
{
    public class SalvarSeguroDTO
    {
        public int NumeroApolice { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string PlacaVeiculo { get; set; }
        public double ValorPremio { get; set; }
    }
}