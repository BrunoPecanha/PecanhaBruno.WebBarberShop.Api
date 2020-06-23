using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pecanha.WebBarberShopp.CrossCutting.EntryContainers.Creating;
using PecanhaBruno.WebBarberShop.Application.Interface;
using PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Updating;
using PecanhaBruno.WebBarberShop.CrossCutting.EntryContainers;
using System;

namespace PecanhaBruno.WebBarberShop.Api.Controllers {
    /// <summary>
    /// Classe que trata da entrada de clientes no sistema.
    /// </summary>
    [AllowAnonymous]
    [Route("api/User")]
    public class UserController : ControllerBase {
        private readonly IUserAppService _userApp;

        /// <summary>
        /// Controller do usuário
        /// </summary>
        /// <param name="userApp">Parâmetro injetado pelo container de IoC.</param>
        public UserController(IUserAppService userApp) {
            _userApp = userApp;
        }


        [Route("Register")]
        [HttpPost]
        public IActionResult Post([FromBody] UserContainer user) {
            try {
                var ret = _userApp.CreateNewUser(user.ToEntity());
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }


        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll() {
            try {
                var ret = _userApp.GetAllUsers();
                return Ok(ret);
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
                var ret = _userApp.GetById(id);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Id = id,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }


        [Route("Update")]
        [HttpPut]
        public IActionResult Put(UpdatingUserDto user) {
            try {
                var ret = _userApp.UpdateUser(user);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }


        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete(int id) {
            try {
                var ret = _userApp.DeleteUser(id);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Id = id,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }
    }
}
