using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PecanhaBruno.WebBarberShop.Domain.Dto;
using PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Creating;
using PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Updating;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using System;

namespace PecanhaBruno.WebBarberShop.Api.Controllers
{
    /// <summary>
    /// Controler da classe Cliente
    /// </summary>
    [AllowAnonymous]
    [Route("api/ServiceType")]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IServiceTypeService _service;

        /// <summary>
        /// Entrada da mensagem de Cliente.
        /// </summary>
        /// <param name="serviceApp"></param>
        public ServiceTypeController(IServiceTypeService serviceApp) {
            _service = serviceApp;
        }

        /// <summary>
        /// Cadastro de um novo serviço
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public IActionResult Post([FromBody] CreatingServiceTypeDto service) {
            try {
                 _service.CreateNewService(service.ToEntity());
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Recupera todas os tipos de serviços por empresa paginado.
        /// </summary>
        /// <param name="companyId">Id da empresa</param>
        /// <param name="page">Pagina que se deseja</param>
        /// <param name="qtd">Quantidade de registros</param>
        /// <returns></returns>
        [HttpGet("GetAll/{companyId}/{page}/{qtd}")]
        public IActionResult GetAll([FromRoute] int companyId, int page, int qtd) {
            try {
                var ret = _service.GetAllServicesType(companyId, page, qtd);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Recupera um serviço pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetById")]
        public IActionResult GetById(int id) {
            try {
                var ret = _service.GetServiceById(id);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Id = id,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Atualiza um registro de serviço
        /// </summary>
        /// <param name="serviceDto">Dto de entrada.</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put(UpdatingServiceTypeDto serviceDto) {
            try {
                _service.UpdateService(serviceDto.ToEntity());
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Exclui um serviço cadastrado ou muda o flag de ativo para false.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete(int id) {
            try {
                _service.TryHardDelete(id);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Id = id,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }


        /// <summary>
        /// Recupera os serviços que o usuário selecionou.
        /// </summary>
        /// <param name="customerId">Id do cliente.</param>
        /// <returns></returns>
        [Route("SelectedServices")]
        [HttpGet]
        public IActionResult GetAll(int customerId)
        {
            try
            {
                var ret = _service.GetServicesByCustomer(customerId);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(new DefaultOutPutContainer()
                {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }       
    }
}
