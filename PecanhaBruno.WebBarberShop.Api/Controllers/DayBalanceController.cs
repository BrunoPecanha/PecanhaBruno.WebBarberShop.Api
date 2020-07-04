using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PecanhaBruno.WebBarberShop.Domain.Dto;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using System;

namespace PecanhaBruno.WebBarberShop.Api.Controllers {
    [AllowAnonymous]
    [Route("api/DayBalance")]
    public class DayBalanceController : ControllerBase {
        private readonly IDayBalanceService _dayBalanceService;

        public DayBalanceController(IDayBalanceService dayBalanceService) {
            _dayBalanceService = dayBalanceService;
        }

        [HttpPost("Withdraw/{companyId}/{value}")]
        public IActionResult Withdraw([FromRoute] int companyId, decimal value) {
            try {
                _dayBalanceService.Withdraw(companyId, value);
                return Ok();
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost("Deposit/{companyId}/{value}")]
        public IActionResult Deposit([FromRoute] int companyId, decimal value) {
            try {
                _dayBalanceService.Deposit(companyId, value);
                return Ok(new DefaultOutPutContainer() {
                    Valid = true,
                    Message = "Done"
                });
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Valid = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("Amount/{companyId}")]
        public IActionResult Amount([FromRoute] int companyId) {
            try {
                var ret = _dayBalanceService.DayAmount(companyId);
                return Ok(ret);
            } catch (Exception ex) {
                return BadRequest(new DefaultOutPutContainer() {
                    Id = companyId,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }
    }
}
