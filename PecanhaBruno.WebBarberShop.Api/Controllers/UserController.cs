using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pecanha.WebBarberShopp.Domain.EntryContainers.Creating;
using Pecanha.WebBarberShopp.Domain.EntryContainers.Updating;
using PecanhaBruno.WebBarberShop.Domain.Dto;
using PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Updating;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using System;

namespace PecanhaBruno.WebBarberShop.Api.Controllers
{
    /// <summary>
    /// Classe que trata da entrada de clientes no sistema.
    /// </summary>
    [AllowAnonymous]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IUserRepository _repository;

        /// <summary>
        /// Controller do usuário
        /// </summary>
        /// <param name="userApp">Parâmetro injetado pelo container de IoC.</param>
        public UserController(IUserService service, IUserRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserContainerCreating user)
        {
            try
            {
                _service.CreateNewUser(user.ToEntity());
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll(int companyId)
        {
            try
            {
                var ret = _repository.GetAllUsers(companyId);
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


        [Route("GetById")]
        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var ret = _repository.GetById(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(new DefaultOutPutContainer()
                {
                    Id = id,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }


        [HttpPut]
        public IActionResult Put(UserContainerUpdating user)
        {
            try
            {
                var ret = _service.UpdateUser(user.ToEntity());
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



        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var ret = _service.DeleteUser(id);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(new DefaultOutPutContainer()
                {
                    Id = id,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }
    }
}
