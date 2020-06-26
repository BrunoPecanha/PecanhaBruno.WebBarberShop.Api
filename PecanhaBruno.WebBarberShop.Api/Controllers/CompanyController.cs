using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using PecanhaBruno.WebBarberShop.Domain.Dto;
using Pecanha.WebBarberShopp.Domain.EntryContainers.Creating;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using Pecanha.WebBarberShopp.Domain.EntryContainers.Updating;

namespace PecanhaBruno.WebBarberShop.Api.Controllers {
    [AllowAnonymous]
    [Route("api/Company")]
    public class CompanyController : ControllerBase {
        private readonly ICompanyService _service;
        private readonly ICompanyRepository _repository;

        public CompanyController(ICompanyService service, ICompanyRepository repository) {
            _service = service;
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CompanyContainerCreating company) {
            try {
                _service.CreateNewCompany(company.ToEntity());
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll() {
            try {
                var ret = _repository.GetAll();
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id) {
            try {
                var ret = _repository.GetCompanyById(id);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Id = id,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPut]
        public IActionResult Put(CompanyContainerUpdating company) {
            try {
                _service.UpdateCompany(company.ToEntity());
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id) {
            try {
                _service.RemoveCompany(id);
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
