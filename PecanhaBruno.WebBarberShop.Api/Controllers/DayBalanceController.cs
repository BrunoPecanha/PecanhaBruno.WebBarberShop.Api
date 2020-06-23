using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pecanha.WebBarberShopp.CrossCutting.EntryContainers.Creating;
using PecanhaBruno.WebBarberShop.Application.Interface;
using PecanhaBruno.WebBarberShop.CrossCutting.EntitiesDto.Updating;
using PecanhaBruno.WebBarberShop.CrossCutting.EntryContainers;
using System;

namespace PecanhaBruno.WebBarberShop.Api.Controllers {
    [AllowAnonymous]
    [Route("api/DayBalance")]
    public class DayBalanceController : ControllerBase
    {
        private readonly IDayBalanceAppService _dayBalanceApp;

        public DayBalanceController(IDayBalanceAppService dayBalanceApp)
        {
            _dayBalanceApp = dayBalanceApp;
        }

        [Route("Withdraw/{companyId}/{value}")]
        [HttpPost]
        public IActionResult Withdraw([FromRoute] int companyId, decimal value)
        {
            try
            {
                var ret = _dayBalanceApp.Withdraw(companyId, value);
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

        [Route("Deposit/{companyId}/{value}")]
        [HttpPost]
        public IActionResult Deposit([FromRoute] int companyId, decimal value)
        {
            try
            {
                var ret = _dayBalanceApp.Deposit(companyId, value);
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
