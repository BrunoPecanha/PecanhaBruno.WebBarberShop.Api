using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pecanha.WebBarberShopp.CrossCutting.EntryContainers.Creating;
using PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Updating;
using PecanhaBruno.WebBarberShop.CrossCutting.EntryContainers;
using PecanhaBruno.WebBarberShop.CrossCutting.EntryContainers.Creating;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using System;

namespace PecanhaBruno.WebBarberShop.Api.Controllers {
    /// <summary>
    /// Controler da classe Cliente
    /// </summary>
    [AllowAnonymous]
    [Route("api/Custumer")]
    public class CustumerController : ControllerBase {
        private readonly ICustumerService _custumerApp;

        /// <summary>
        /// Entrada da mensagem de Cliente.
        /// </summary>
        /// <param name="companyService"></param>
        public CustumerController(ICustumerService companyService) {
            _custumerApp = companyService;
        }

        /// <summary>
        /// Método para criar um novo cliente.
        /// </summary>
        /// <param name="custumer">Usuário que será transformado em cliente.</param>

        [Route("Register")]
        [HttpPost]
        public IActionResult Post([FromBody] CustumerContainer custumer) {
            try {
                _custumerApp.SaveCustumerSelectedServices(custumer.ToEntity(), custumer.CustumerMessage.ServiceList);             
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
                var ret = _custumerApp.GetById(id);
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
                var ret = _custumerApp.GetCostumerByName(name);
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
                var ret = _custumerApp.DeleteFromQueue(id);
                return Ok(ret);
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
                var ret = _custumerApp.UpdaSelectedServices(customer);
                return Ok(ret);
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
                var ret = _custumerApp.EndCustomerService(customerId, companyId);
                return Ok(ret);
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
                var ret = _custumerApp.ElapsedTime(customerId);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }


        /// <summary>
        /// Altera a posição do cliente na fila
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        //[Route("ChangePositionInQueue")]
        //[HttpPost]
        //public IActionResult Put([FromBody] CustumerContainerDto customer) {
        //}        
    }
}
