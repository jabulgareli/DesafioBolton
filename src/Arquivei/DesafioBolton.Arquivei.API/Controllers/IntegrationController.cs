using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioBolton.Bolton.Application.NFes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioBolton.Arquivei.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrationController : ControllerBase
    {
        private readonly INfeAppService _nfeIntegrationApp;

        public IntegrationController(INfeAppService nfeIntegrationApp)
        {
            _nfeIntegrationApp = nfeIntegrationApp;
        }

        [HttpPost("nfe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Nfe()
        {
            try
            {
                await _nfeIntegrationApp.RunIntegrationAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, string.Empty);
            }
            
        }
    }
}