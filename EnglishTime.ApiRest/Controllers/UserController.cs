using AutoMapper;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.JsonPatch;

using EnglishTime.Core.Provider.Interfaces;
using EnglishTime.ApiRest.Dtos;
using EnglishTime.Data.Model;

namespace EnglishTime.ApiRest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserProvider _provider;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(
            IUserProvider provider,
            ILogger<UserController> logger,
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
                return Ok(_mapper.Map<ICollection<UserDto>>(_provider.GetAllUsers()));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Get user exception");
                return StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _provider.GetUser(id);
                if (result != null)
                    return Ok(result);

                return NotFound();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Get user by id exception");
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Add(UserDto userDto)
        {
            try
            {
                var errors = userDto.VerifyUserParameters();
                if (errors.Error)
                    return BadRequest(errors);

                var user = _mapper.Map<User>(userDto);
                if (_provider.IsEmailAlreadyRegistered(user.Email))
                    return BadRequest(new ErrorDto { Error = true, Messages = new List<string> { "Email already registered." } });

                var result = _provider.CreateUser(user);
                if (!result)
                    return StatusCode(500);

                return CreatedAtRoute(nameof(Get), new { id = user.Id }, _mapper.Map<UserDto>(user));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Add user exception");
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserDto userDto)
        {
            try
            {
                var errors = userDto.VerifyUserParameters();
                if (errors.Error)
                    return BadRequest(errors);

                if (_provider.IsEmailAlreadyRegistered(userDto.Email))
                    return BadRequest(new ErrorDto { Error = true, Messages = new List<string> { "Email already registered." } });

                var userFromDatabase = _provider.GetUser(id);
                if (userFromDatabase == null)
                    return NotFound();

                _mapper.Map(userDto, userFromDatabase);

                var result = _provider.UpdateUser(userFromDatabase);
                if (!result)
                    return StatusCode(500);

                return Ok(_mapper.Map<UserDto>(userFromDatabase));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Update user exception");
                return StatusCode(500);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, JsonPatchDocument<UserDto> patchUser)
        {
            try
            {
                var userFromDatabase = _provider.GetUser(id);
                if (userFromDatabase == null)
                    return NotFound();

                if (patchUser.Operations.Count > 0 && patchUser.Operations[0].path.Equals("/Email"))
                {
                    // TODO fix this validation
                    var email = patchUser.Operations[0].value.ToString();
                    if (_provider.IsEmailAlreadyRegistered(email))
                        return BadRequest(new ErrorDto { Error = true, Messages = new List<string> { "Email already registered." } });
                }

                var userToPatch = _mapper.Map<UserDto>(userFromDatabase);

                patchUser.ApplyTo(userToPatch, ModelState);

                if (!TryValidateModel(userToPatch))
                    return ValidationProblem(ModelState);

                _mapper.Map(userToPatch, userFromDatabase);
                var result = _provider.UpdateUser(userFromDatabase);
                if (!result)
                    return StatusCode(500);

                return Ok(_mapper.Map<UserDto>(userFromDatabase));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Update user by patch exception");
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var userFromDatabase = _provider.GetUser(id);
                if (userFromDatabase == null)
                    return NotFound();

                var result = _provider.DeleteUser(userFromDatabase);
                if (!result)
                    return StatusCode(500);

                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Delete user exception");
                return StatusCode(500);
            }
        }

        [HttpOptions]
        public IActionResult Resources()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", new[] { "https://localhost:5001" });
            Response.Headers.Add("Access-Control-Allow-Headers", new[] { "Content-Type: application/json; charset=utf-8" });
            Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, PATCH, DELETE, OPTIONS" });
            Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "false" });

            return Ok();
        }
    }
}
