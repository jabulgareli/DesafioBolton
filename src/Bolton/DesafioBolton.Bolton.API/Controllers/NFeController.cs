using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioBolton.Bolton.API.Model;
using DesafioBolton.Bolton.Application.NFes;
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
        private readonly INfeAppService _nfeAppService;

        public NFeController(INfeAppService nfeAppService)
        {
            _nfeAppService = nfeAppService;
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
                var nfe = await _nfeAppService.FindNFeByAccessKeyAsync(accessKey);

                if (nfe is null)
                {
                    return NotFound();
                }

                return Ok(NFeModel.FromNFe(nfe));
            }
            catch (Exception ex)
            {
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
                var nfe = await _nfeAppService.FindNFeByAccessKeyAsync(accessKey);

                if (nfe is null)
                {
                    return NotFound();
                }

                return Ok(nfe);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}