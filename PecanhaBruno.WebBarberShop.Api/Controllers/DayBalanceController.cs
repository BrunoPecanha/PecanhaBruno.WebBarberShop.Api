using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PecanhaBruno.WebBarberShop.CrossCutting.EntryContainers;
using PecanhaBruno.WebBarberShop.Domain.Interface.Service;
using System;

namespace PecanhaBruno.WebBarberShop.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/DayBalance")]
    public class DayBalanceController : ControllerBase
    {
        private readonly IDayBalanceService _dayBalanceService;

        public DayBalanceController(IDayBalanceService dayBalanceService)
        {
            _dayBalanceService = dayBalanceService;
        }

        [Route("Withdraw/{companyId}/{value}")]
        [HttpPost]
        public IActionResult Withdraw([FromRoute] int companyId, decimal value)
        {
            try
            {
                _dayBalanceService.Withdraw(companyId, value);
                return Ok();
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

        [Route("Deposit/{companyId}/{value}")]
        [HttpPost]
        public IActionResult Deposit([FromRoute] int companyId, decimal value)
        {
            try
            {
                var ret = _dayBalanceService.Deposit(companyId, value);
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

        [Route("Amount/{companyId}")]
        [HttpGet]
        public IActionResult Amount([FromRoute] int companyId)
        {
            try
            {
                var ret = _dayBalanceApp.DayAmount(companyId);
                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(new DefaultOutPutContainer()
                {
                    Id = companyId,
                    Valid = false,
                    Message = ex.Message
                });
            }
        }
    }
}
