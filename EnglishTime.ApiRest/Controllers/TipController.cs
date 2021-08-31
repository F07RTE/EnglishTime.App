using AutoMapper;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

using EnglishTime.Core.Provider.Interfaces;
using EnglishTime.ApiRest.Dtos;
using EnglishTime.Data.Model;

namespace EnglishTime.ApiRest.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class TipController : ControllerBase
    {
        private readonly ITipProvider _provider;
        private readonly ILogger<TipController> _logger;
        private readonly IMapper _mapper;

        public TipController(
            ITipProvider provider,
            ILogger<TipController> logger,
            IMapper mapper
            )
        {
            _provider = provider;
            _logger = logger;
            _mapper = mapper;
        }

          [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<ICollection<TipDto>>(_provider.GetAllTips()));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Get tip exception");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "GetTip")]
        public IActionResult GetTip(int id)
        {
            try
            {
                var result = _provider.GetTip(id);
                if (result != null)
                    return Ok(result);

                return NotFound();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Get tip by id exception");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Add(TipDto tipDto)
        {
            try
            {
                var errors = tipDto.VerifyTipParameters();
                if (errors.Error)
                    return BadRequest(errors);

                var tip = _mapper.Map<Tip>(tipDto);

                var result = _provider.CreateTip(tip);
                if (!result)
                    return StatusCode(500);

                return CreatedAtRoute(nameof(GetTip), new { id = tip.Id }, _mapper.Map<TipDto>(tip));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Add tip exception");
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TipDto tipDto)
        {
            try
            {
                var errors = tipDto.VerifyTipParameters();
                if (errors.Error)
                    return BadRequest(errors);

                var tipFromDatabase = _provider.GetTip(id);
                if (tipFromDatabase == null)
                    return NotFound();

                _mapper.Map(tipDto, tipFromDatabase);

                var result = _provider.UpdateTip(tipFromDatabase);
                if (!result)
                    return StatusCode(500);

                return Ok(_mapper.Map<TipDto>(tipFromDatabase));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Update tip exception");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var tipFromDatabase = _provider.GetTip(id);
                if (tipFromDatabase == null)
                    return NotFound();

                var result = _provider.DeleteTip(tipFromDatabase);
                if (!result)
                    return StatusCode(500);

                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Delete tip exception");
                return StatusCode(500);
            }
        }
    }
}