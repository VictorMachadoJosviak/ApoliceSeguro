using Apolice.Domain.DTO.Seguro;
using Apolice.Domain.Entity.Base;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolice.Domain.Entity
{
    public class Seguro : EntityBase
    {
        public Seguro()
        {
        }

        public Seguro(int numeroApolice, string cpf, string cnpj, string placaVeiculo, double valorPremio)
        {
            NumeroApolice = numeroApolice;
            Cpf = cpf;
            Cnpj = cnpj;
            PlacaVeiculo = placaVeiculo;
            ValorPremio = valorPremio;
            if (!string.IsNullOrEmpty(cpf))
                new AddNotifications<Seguro>(this).IfNotCpf(x => x.Cpf, "Cpf inválido");
            if (!string.IsNullOrEmpty(cnpj))
                new AddNotifications<Seguro>(this).IfNotCnpj(x => x.Cnpj, "Cnpj inválido");
        }

        public int NumeroApolice { get; set; }
        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string PlacaVeiculo { get; set; }
        public double ValorPremio { get; set; }

        public static explicit operator SeguroDTO(Seguro s)
        {
            return new SeguroDTO
            {
                Cnpj = s.Cnpj,
                Cpf = s.Cpf,
                Id = s.Id,
                NumeroApolice = s.NumeroApolice,
                PlacaVeiculo = s.PlacaVeiculo,
                ValorPremio = s.ValorPremio
            };
        }
    }
}