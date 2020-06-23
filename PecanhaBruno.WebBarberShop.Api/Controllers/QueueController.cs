﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pecanha.WebBarberShopp.CrossCutting.EntryContainers.Creating;
using PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Updating;
using PecanhaBruno.WebBarberShop.CrossCutting.EntryContainers;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using System;

namespace PecanhaBruno.WebBarberShop.Api.Controllers {
    [AllowAnonymous]
    [Route("api/Queue")]
    public class QueueController : ControllerBase {
        private readonly ICurrentQueueService _queueApp;

        public QueueController(ICurrentQueueService queueApp) {
            _queueApp = queueApp;
        }

        /// <summary>
        /// Cria uma nova fila para o dia atual.
        /// </summary>
        /// <param name="queue">Dto de entrada para criação da fila</param>
        /// <returns></returns>
        [Route("CreateQueue")]  // Colocar para o ID da fila ser somente o id do TO
        [HttpPost]
        public IActionResult Post([FromBody] QueueContainer queue) {
            try {
                var ret = _queueApp.StartQueue(queue.ToEntity());
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Recuperar todas as filas disponíveis.
        /// </summary>
        /// <param name="page">Número da página atual.</param>
        /// <param name="qtd">Quantidade de itens por página.</param>
        /// <returns></returns>
        [Route("GetAllQueues/{page}/{qtd}")]
        [HttpGet]
        public IActionResult GetAll([FromRoute] int page, int qtd) {
            try {
                var ret = _queueApp.GetAllCurrentQueues(page, qtd);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Recuperar fila pelo Id.
        /// </summary>
        /// <param name="id">Id da fila.</param>
        /// <returns></returns>
        [Route("GetQueue/{id}")]
        [HttpGet]
        public IActionResult GetById([FromRoute]int id) {
            try {
                var ret = _queueApp.GetById(id);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Verifica se existe fila iniciada para a empresa.
        /// </summary>
        /// <param name="repository">Instância de repositório para fila.</param>
        /// <param name="companyId">Id da empresa.</param>
        /// <returns></returns>
        [Route("IsThereQueueStarted/{companyId}")]
        [HttpGet]
        public IActionResult IsThereQueueStarted([FromServices] ICurrentQueueRepository repository, [FromRoute]int companyId) {
            try {
                var ret = repository.IsThereQueueStarted(companyId);
                return Ok(new DefaultOutPutContainer() {
                    Valid = true,
                    Log = true

                }); ;
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Finaliza uma fila para aquele dia.
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <param name="userId">Id do usuário dono da fila ( e da empresa ).</param>
        /// <returns></returns>
        [Route("FinishQueue/{companyId}/{userId}")]
        [HttpPut]
        public IActionResult Put([FromRoute]int companyId, int userId) {
            try {
                _queueApp.FinishQueue(companyId, userId);
                return Ok();               
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Recupera todos os cliente da fila atual
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <returns></returns>
        [Route("GetAllCustumersInCurrentQueue/{companyId}")]
        [HttpGet]
        public IActionResult GetAll([FromRoute] int companyId) {
            try {
                var ret = _queueApp.GetAllCustumersInCurrentQueue(companyId);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        /// <summary>
        /// Recupera o último da fila
        /// </summary>
        /// <param name="companyId">Id da empresa.</param>
        /// <returns></returns>
        [Route("GetLastInCurrentQueue/{companyId}")]
        [HttpGet]
        public IActionResult GetLastInCurrentQueue([FromRoute] int companyId) {
            try {
                var ret = _queueApp.GetLastInCurrentQueue(companyId);
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