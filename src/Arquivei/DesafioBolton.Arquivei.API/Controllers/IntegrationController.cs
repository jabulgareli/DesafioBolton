using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioBolton.Bolton.Application.NFe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioBolton.Arquivei.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegrationController : ControllerBase
    {
        private readonly INfeIntegrationAppService _nfeIntegrationApp;
        private readonly ILogger<IntegrationController> _logger;

        public IntegrationController(INfeIntegrationAppService nfeIntegrationApp, 
            ILogger<IntegrationController> logger)
        {
            _nfeIntegrationApp = nfeIntegrationApp;
            _logger = logger;
        }

        [HttpPost("nfe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Nfe()
        {
            try
            {
                await _nfeIntegrationApp.Run();
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, string.Empty);
            }
            
        }
    }
}