using IE3_PRELIM_Q2_32A3_Albano_Raven.DTO.Users;
using Microsoft.AspNetCore.Mvc;

namespace IE3_PRELIM_Q2_32A3_Albano_Raven.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        // GET: api/UserGroup
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new GetUserIDResponse
            {
                Id = 0,
                Message = "Hello from UserGroupController!"
            });
        }

        // GET: api/UserGroup/5
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

        // POST: api/UserGroup
        [HttpPost]
        public IActionResult Post([FromBody] AddUserGroupRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Email))
            {
                return BadRequest(new AddUserResponse
                {
                    Message = "Name and Email are required!"
                });
            }

            return Ok(new AddUserResponse
            {
                Message = "User Created Successful!",
                User = request
            });
        }
    }
}