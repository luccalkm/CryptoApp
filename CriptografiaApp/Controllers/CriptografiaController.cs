using CriptografiaApp.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace CriptografiaApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CriptografiaController : Controller
{
    private readonly CryptoService _cryptoService;

    public CriptografiaController(CryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    [HttpPost("Codificar")]
    public ActionResult<string> CriptografarTexto(string texto)
    {
        if (texto.Length == 0) return BadRequest("O texto enviado é vazio.");

        var textoCodificado = _cryptoService.Encrypt(texto);

        return Ok(textoCodificado);
    }

    [HttpPost("Decodificar")]
    public ActionResult<string> DescriptografarTexto(string textoCodificado)
    {
        if (textoCodificado.Length == 0) return BadRequest("O texto enviado é vazio.");

        var textoDecodificado = _cryptoService.Decrypt(textoCodificado);

        return Ok(textoDecodificado);
    }
}
