using Apolice.API.Controllers.Base;
using Apolice.Domain.DTO.Seguro;
using Apolice.Domain.Interfaces.Services;
using Apolice.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Apolice.API.Controllers
{
    [RoutePrefix("api/seguro")]
    public class SeguroController : ControllerBase
    {
        private readonly ISeguroService seguroService;

        public SeguroController(IUnitOfWork unitOfWork, ISeguroService _seguroService) : base(unitOfWork)
        {
            seguroService = _seguroService;
        }

        [Route("listar")]
        [HttpGet]
        public async Task<HttpResponseMessage> Listar()
        {
            try
            {
                var lista = seguroService.Listar();
                return await ResponseAsync(lista, seguroService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("obterPorId")]
        [HttpGet]
        public async Task<HttpResponseMessage> ObterPorId(Guid? id)
        {
            try
            {
                var seguro = seguroService.ObterPorId(id.GetValueOrDefault());
                return await ResponseAsync(seguro, seguroService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("cadastrar")]
        [HttpPost]
        public async Task<HttpResponseMessage> Cadastrar(SalvarSeguroDTO seguro)
        {
            try
            {
                var seguroSalvo = seguroService.Cadastrar(seguro);
                return await ResponseAsync(seguroSalvo, seguroService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("editar")]
        [HttpPut]
        public async Task<HttpResponseMessage> Editar(SeguroDTO seguro)
        {
            try
            {
                var seguroSalvo = seguroService.Editar(seguro);
                return await ResponseAsync(seguroSalvo, seguroService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }

        [Route("deletar")]
        [HttpDelete]
        public async Task<HttpResponseMessage> Deletar([FromBody] DeletarSeguroDTO seguro)
        {
            try
            {
                var seguroSalvo = seguroService.Deletar(seguro.Id);
                return await ResponseAsync(seguroSalvo, seguroService);
            }
            catch (Exception ex)
            {
                return await ResponseExceptionAsync(ex);
            }
        }
    }
}