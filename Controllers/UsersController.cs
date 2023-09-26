using apitechconecta_prototype.Models;
using apitechconecta_prototype.Services;
using Microsoft.AspNetCore.Mvc;

namespace apitechconecta_prototype.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly TechConectaService _userService;

    public UsersController(TechConectaService userService) => _userService = userService;


    [HttpGet("{userid}")]
    public async Task<IActionResult> Get(int userid)
    {
        var existingUser = await _userService.GetUserAsync(userid);

        if (existingUser is null)
        {
            return NotFound();
        }

        return Ok(existingUser);
    }

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var allUsers = await _userService.GetUsersAsync();

        if (allUsers.Any())
            return Ok(allUsers);

        return NotFound();
    }
}
