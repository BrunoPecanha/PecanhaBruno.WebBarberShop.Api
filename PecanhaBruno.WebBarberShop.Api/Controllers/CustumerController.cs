using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pecanha.WebBarberShopp.Domain.EntryContainers.Creating;
using PecanhaBruno.WebBarberShop.Domain.Dto;
using PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Updating;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using System;

namespace PecanhaBruno.WebBarberShop.Api.Controllers {
    /// <summary>
    /// Controler da classe Cliente
    /// </summary>
    [AllowAnonymous]
    [Route("api/Custumer")]
    public class CustumerController : ControllerBase {
        private readonly ICustumerService _service;

        /// <summary>
        /// Entrada da mensagem de Cliente.
        /// </summary>
        /// <param name="companyService"></param>
        public CustumerController(ICustumerService companyService) {
            _service = companyService;
        }

        /// <summary>
        /// Método para criar um novo cliente.
        /// </summary>
        /// <param name="custumer">Usuário que será transformado em cliente.</param>
        [HttpPost]
        public IActionResult Post([FromBody] CustumerContainerCreating custumer) {
            try {
                _service.SaveCustumerSelectedServices(custumer.CustumerMessage.CompanyId, custumer.ToEntity(), custumer.CustumerMessage.ServiceList);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [Route("GetById")]
        [HttpGet]
        public IActionResult GetById(int id) {
            try {
                var ret = _service.GetById(id);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [Route("GetCostumerByName/{name}")]
        [HttpGet]
        public IActionResult GetCostumerByName([FromRoute] string name) {
            try {
                var ret = _service.GetCustomerByName(name);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Remove um cliente da fila
        /// </summary>
        /// <param name="id">Id do cliente.</param>
        /// <returns></returns>
        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete(int id) {
            try {
                 _service.DeleteFromQueue(id);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Atualiza os serviços do usuário.
        /// </summary>
        /// <param name="customer">Objeto do cliente.</param>
        /// <returns></returns>
        [Route("UpdateCustomerServices")]
        [HttpPut]
        public IActionResult Put([FromBody] UpdatingCustumerDto customer) {
            try {
                 _service.UpdateCustomer(customer.CompanyId, customer.CustumerId,  customer.ServiceList, customer.Comment);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Finaliza o atendimento a um cliente.
        /// </summary>
        /// <param name="customerId">Id do cliente.</param>
        /// <param name="customerId">Id da empresa.</param>
        /// <returns></returns>
        [Route("EndCustomerService/{companyId}/{customerId}")]
        [HttpPut]
        public IActionResult Put([FromRoute] int companyId, int customerId) {
            try {
                 _service.EndCustomerService(customerId, companyId);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Consulta quanto tempo o cliente está esperando.
        /// </summary>
        /// <param name="customerId">Id do cliente.</param>
        /// <returns></returns>
        [Route("ElapsedTime/{customerId}")]
        [HttpPut]
        public IActionResult Get([FromRoute] int customerId) {
            try {
                var ret = _service.ElapsedTime(customerId);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }
    }
}
