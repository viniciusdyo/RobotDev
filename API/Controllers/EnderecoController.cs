using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
[Route("[controller]")]
public class EnderecoController(IEnderecoService service) : ControllerBase
{
    [HttpPost]
    [Route("list")]
    public async Task<IActionResult> AddAsync(List<EnderecoModel> model)
    {
        await service.AddAsync(model);
        return Ok(new { Message = "Ceps cadastrados com sucesso!" });
    }

    [HttpPut]
    [Route("AtualizarDados")]
    public async Task<IActionResult> UpdateAsync(EnderecoModel model)
    {
        await service.AtualizarDados(model);
        return Ok(new { Message = "Ceps atualizados com sucesso!" });
    }

    [HttpGet]
    [Route("ObterCepParaTratamento")]
    public async Task<IActionResult> ObterCepParaTratamento(string robo)
    {
        var cep = await service.ObterCEPParaTratamento(robo);
        return Ok(cep);
    }

    [HttpGet]
    public async Task<IActionResult> ListAsync()
    {
        var enderecos = await service.ObterTodos();
        return Ok(enderecos);
    }

}
