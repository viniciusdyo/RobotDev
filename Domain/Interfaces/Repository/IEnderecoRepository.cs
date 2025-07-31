using Domain.Entidades;

namespace Domain.Interfaces.Repository;

public interface IEnderecoRepository
{
    Task AddAsync(List<Endereco> enderecos);
    Task<Endereco?> ObterCEPParaTratamentoAsync(string robo);
    Task AtualizarDados(Endereco endereco);
    Task<Endereco?> ObterPorIdAsync(int id);
    Task<List<Endereco>> ObterTodosAsync();
}
