using apitechconecta_prototype.Models;
using apitechconecta_prototype.Services;
using Microsoft.AspNetCore.Mvc;

namespace apitechconecta_prototype.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly TechConectaService _postService;

    public PostsController(TechConectaService postService) => _postService = postService;

    [HttpGet("all")]
    public async Task<IActionResult> Get()
    {
        var allPosts = await _postService.GetPostsAsync();

        if (allPosts.Any()) 
            return Ok(allPosts);

        return NotFound();
    }

    [HttpGet("{postid}")]
    public async Task<IActionResult> Get(int postid)
    {
        var existingPost = await _postService.GetPostAsync(postid);

        if(existingPost is null)
        {
            return NotFound();
        }

        return Ok(existingPost);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Post post)
    {
        await _postService.CreateAsync(post);
        return CreatedAtAction(nameof(Post), new {id = post.PostId}, post);
    }

    [HttpPut]
    public async Task<IActionResult> Update(int postid,Post post)
    {
        var existingPost = await _postService.GetPostAsync(postid);

        if (existingPost is null)
        {
            return NotFound();
        }

        post.PostId = existingPost.PostId;

        await _postService.UpdateAsync(post);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int postid){
        var existingPost = await _postService.GetPostAsync(postid);

        if (existingPost is null)
        {
            return NotFound();
        }

        await _postService.RemoveAsync(postid);
        return NoContent();
    }
}