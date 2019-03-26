using Apolice.Domain.DTO.Seguro;
using Apolice.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apolice.Domain.Interfaces.Services
{
    public interface ISeguroService : IServiceBase
    {
        SeguroDTO Cadastrar(SalvarSeguroDTO dto);

        SeguroDTO Editar(SeguroDTO dto);

        List<SeguroDTO> Listar();

        bool Deletar(Guid id);
    }
}