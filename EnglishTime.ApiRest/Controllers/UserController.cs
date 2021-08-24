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
            return Ok(_mapper.Map<ICollection<UserDto>>(_provider.GetAllUsers()));
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _provider.GetUser(id);
                if (result != null)
                    return Ok();

                return NotFound();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPost]
        public IActionResult Add(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                var result = _provider.CreateUser(user);
                if (!result)
                    return BadRequest();

                return CreatedAtRoute(nameof(Get), new { id = user.Id }, _mapper.Map<UserDto>(user));
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [HttpPut]
        public IActionResult Update(UserDto userDto)
        {
            try
            {
                var userFromDatabase = _provider.GetUser(userDto.Id);
                if (userFromDatabase == null)
                    return NotFound();

                _mapper.Map(userDto, userFromDatabase);

                var result = _provider.UpdateUser(userFromDatabase);
                if (!result)
                    return BadRequest();

                return Ok(_mapper.Map<UserDto>(userFromDatabase));
            }
            catch (Exception exception)
            {
                throw exception;
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

                var userToPatch = _mapper.Map<UserDto>(userFromDatabase);

                patchUser.ApplyTo(userToPatch, ModelState);

                if (!TryValidateModel(userToPatch))
                    return ValidationProblem(ModelState);

                _mapper.Map(userToPatch, userFromDatabase);
                var result = _provider.UpdateUser(userFromDatabase);

                if (!result)
                    return BadRequest();

                return Ok(_mapper.Map<UserDto>(userFromDatabase));
            }
            catch (Exception exception)
            {
                throw exception;
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
                    return BadRequest();

                return NoContent();
            }
            catch (Exception exception)
            {
                throw exception;
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
