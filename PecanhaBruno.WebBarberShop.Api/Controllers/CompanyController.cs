using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pecanha.WebBarberShopp.CrossCutting.EntryContainers.Creating;
using PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Updating;
using PecanhaBruno.WebBarberShop.CrossCutting.EntryContainers;
using System;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;

namespace PecanhaBruno.WebBarberShop.Api.Controllers {
    [AllowAnonymous]
    [Route("api/Company")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyApp;

        public CompanyController(ICompanyService companyAppService) {
            _companyApp = companyAppService;
        }

        [Route("Register")]
        [HttpPost]
        public IActionResult Post([FromBody] CompanyContainer company) {

            try {
                _companyApp.CreateNewCompany(company.ToEntity(), company.CompanyMessage.UserId);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll() {
            try {
                var ret = _companyApp.GetAll();
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
                var ret = _companyApp.GetCompanyAndUserById(id);
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
        public IActionResult Put(UpdatingCompanyDto company) {
            try {
                _companyApp.UpdateCompany(company.ToEntity());
                return Ok();                
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
                _companyApp.RemoveCompany(id);
                return Ok();               
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
