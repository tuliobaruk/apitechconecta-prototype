using apitechconecta_prototype.Models;
using apitechconecta_prototype.Services;
using Microsoft.AspNetCore.Mvc;

namespace apitechconecta_prototype.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private readonly TechConectaService _commentService;

    public CommentsController(TechConectaService commentService) => _commentService = commentService;

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var allComments = await _commentService.GetCommentsAsync();

        if (allComments.Any())
            return Ok(allComments);

        return NotFound();
    }

    [HttpGet("{postid}")]
    public async Task<IActionResult> Get(int postid)
    {
        var existingComment = await _commentService.GetCommentAsync(postid);

        if (existingComment is null)
        {
            return NotFound();
        }

        return Ok(existingComment);
    }
}
