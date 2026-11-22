using IE3_PRELIM_Q2_32A3_Albano_Raven.DTO.Users;
using Microsoft.AspNetCore.Mvc;

namespace IE3_PRELIM_Q2_32A3_Albano_Raven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new GetUserIDResponse
            {
                Id = 0,
                Message = "Hello from UserController!"
            });
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
            {
                return BadRequest(new GetUserIDResponse
                {
                    Id = id,
                    Message = "Invalid user ID!"
                });
            }

            if (id < 0)
            {
                return NotFound(new GetUserIDResponse
                {
                    Id = id,
                    Message = $"User with ID {id} not found!"
                });
            }

            return Ok(new GetUserIDResponse
            {
                Id = id,
                Message = $"You requested user with ID {id}"
            });
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] AddUserRequest value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.Name) || string.IsNullOrWhiteSpace(value.Email))
            {
                return BadRequest(new AddUserResponse
                {
                    Message = "Name and Email are required!"
                });
            }

            return Ok(new AddUserResponse
            {
                Message = "User created successfully!",
                User = value
            });
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AddUserByID value)
        {
            if (id == 0)
            {
                return BadRequest(new GetUserIDResponse
                {
                    Id = id,
                    Message = "Invalid user ID!"
                });
            }

            if (id < 0)
            {
                return NotFound(new GetUserIDResponse
                {
                    Id = id,
                    Message = $"User with ID {id} not found!"
                });
            }

            value.Id = id;

            return Ok(new AddUserResponse
            {
                Message = $"User with ID {id} updated successfully!",
                User = value
            });
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest(new GetUserIDResponse
                {
                    Id = id,
                    Message = "Invalid user ID!"
                });
            }

            if (id < 0)
            {
                return NotFound(new GetUserIDResponse
                {
                    Id = id,
                    Message = $"User with ID {id} not found!"
                });
            }

            return Ok(new GetUserIDResponse
            {
                Id = id,
                Message = $"User with ID {id} deleted successfully!"
            });
        }
    }
}