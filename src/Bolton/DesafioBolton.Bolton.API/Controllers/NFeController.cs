using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioBolton.Bolton.API.Model;
using DesafioBolton.Bolton.Domain.Core.NFes.Aggregates;
using DesafioBolton.Bolton.Domain.Core.NFes.Ports.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DesafioBolton.Bolton.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NFeController : ControllerBase
    {
        private readonly ILogger<NFeController> _logger;
        private readonly INFeRepository _nFeRepository;

        public NFeController(ILogger<NFeController> logger, INFeRepository nFeRepository)
        {
            _logger = logger;
            _nFeRepository = nFeRepository;
        }

        [HttpGet("{accessKey}/amount")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NFeModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetValueNFeByAccessKey(string accessKey)
        {
            if (string.IsNullOrEmpty(accessKey))
                return BadRequest();

            try
            {
                var nfe = await _nFeRepository.FindAsync(accessKey);

                if (nfe is null)
                {
                    return NotFound();
                }

                return Ok(NFeModel.FromNFe(nfe));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{accessKey}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NFe))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetNFeByAccessKey(string accessKey)
        {
            if (string.IsNullOrEmpty(accessKey))
                return BadRequest();

            try
            {
                var nfe = await _nFeRepository.FindAsync(accessKey);

                if (nfe is null)
                {
                    return NotFound();
                }

                return Ok(nfe);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}