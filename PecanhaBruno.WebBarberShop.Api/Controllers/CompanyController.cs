using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PecanhaBruno.WebBarberShop.Domain.Dto;
using PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Creating;
using PecanhaBruno.WebBarberShop.Domain.Dto.EntitiesDto.Updating;
using PecanhaBruno.WebBarberShop.Domain.Interface.Repository;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using System;

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
        public IActionResult Post([FromBody] CreatingCompanyDto company) {
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
                return Ok(new DefaultOutPutContainer() {
                    Valid = false,
                    Log = ret
                });
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
                return Ok(new DefaultOutPutContainer() {
                    Valid = false,
                    Log = ret
                });
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Id = id,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPut]
        public IActionResult Put(UpdatingCompanyDto company) {
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
