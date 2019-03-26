using Apolice.Domain.DTO.Seguro;
using Apolice.Domain.Entity;
using Apolice.Domain.Interfaces.Repositories;
using Apolice.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolice.Domain.Services
{
    public class SeguroService : Notifiable, ISeguroService
    {
        private readonly ISeguroRepository seguroRepository;

        public SeguroService(ISeguroRepository _seguroRepository)
        {
            seguroRepository = _seguroRepository;
        }

        public List<SeguroDTO> Listar()
        {
            return seguroRepository.Listar().ToList().Select(x => (SeguroDTO)x).ToList();
        }

        public SeguroDTO Cadastrar(SalvarSeguroDTO dto)
        {
            SeguroDTO segurodto = null;
            var seguro = new Seguro(dto.NumeroApolice, dto.Cpf, dto.Cnpj, dto.PlacaVeiculo, dto.ValorPremio);
            AddNotifications(seguro);
            if (seguro.IsValid())
            {
                var existe = seguroRepository.Existe(x => x.Cnpj == seguro.Cnpj || x.Cpf == seguro.Cpf);
                if (existe)
                {
                    AddNotification("seguro", "seguro já cadastrado");
                    return null;
                }
                segurodto = (SeguroDTO)seguroRepository.Adicionar(seguro);
            }
            return segurodto;
        }

        public SeguroDTO Editar(SeguroDTO dto)
        {
            SeguroDTO seguroDto = null;
            var seguro = seguroRepository.ObterPorId(dto.Id);
            if (seguro != null)
            {
                seguro.Cnpj = dto.Cnpj;
                seguro.Cpf = dto.Cpf;
                seguro.UpdatedAt = DateTime.Now;
                seguro.ValorPremio = dto.ValorPremio;
                seguro.PlacaVeiculo = dto.PlacaVeiculo;
                seguro.NumeroApolice = dto.NumeroApolice;
                AddNotifications(seguro);
                if (seguro.IsValid())
                {
                    seguroDto = (SeguroDTO)seguroRepository.Editar(seguro);
                    return seguroDto;
                }
            }
            return seguroDto;
        }

        public bool Deletar(Guid id)
        {
            var seguro = seguroRepository.ObterPorId(id);
            if (seguro != null)
            {
                seguroRepository.Remover(seguro);
                return true;
            }
            return false;
        }
    }
}