using Microsoft.AspNetCore.Mvc;
using apitechconecta_prototype.Services;
using apitechconecta_prototype.Models;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/imagens")]
public class ImagesController : ControllerBase
{
    private readonly TechConectaService _imageService;

    public ImagesController(TechConectaService imageService) => _imageService = imageService;

    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    [SwaggerOperation(Summary = "Upload de Imagem")]
    public async Task<IActionResult> UploadImagem([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Nenhum arquivo enviado.");

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            var image = new Images
            {
                Name = file.FileName,
                TypeMIME = file.ContentType,
                Data = memoryStream.ToArray()
            };

            await _imageService.InsertOneAsync(image);
        }

        return Ok("Imagem enviada com sucesso.");
    }
}
