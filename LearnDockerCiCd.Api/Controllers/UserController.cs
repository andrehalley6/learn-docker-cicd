using LearnDockerCiCd.Application.DTO;
using LearnDockerCiCd.Application.Interfaces;
using LearnDockerCiCd.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearnDockerCiCd.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService, ILogger<UserController> logger) : ControllerBase
{
    private readonly IUserService _userService = userService;
    private readonly ILogger<UserController> _logger = logger;

    [HttpGet]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        try
        {
            var users = await _userService.GetAllUsersAsync(cancellationToken);
            return Ok(users);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving users");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByID(int id, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userService.GetUserAsync(id, cancellationToken);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving user with ID {Id}", id);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto, CancellationToken cancellationToken)
    {
        if (createUserDto == null)
        {
            return BadRequest("Invalid user data");
        }

        try
        {
            var createdUser = await _userService.CreateUserAsync(createUserDto, cancellationToken);
            return CreatedAtAction(nameof(GetUserByID), new { id = createdUser.ID }, createdUser);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating user");
            return StatusCode(500, "Internal server error");
        }
    }
}