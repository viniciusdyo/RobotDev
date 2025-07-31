using Domain.Entidades;
using Domain.Models;

namespace Domain.Interfaces.Services;

public interface IEnderecoService
{
    Task AddAsync(List<EnderecoModel> enderecos);
    Task<EnderecoModel> ObterCEPParaTratamento(string robo);
    Task AtualizarDados(EnderecoModel endereco);
    Task<List<EnderecoModel>> ObterTodos();
}
