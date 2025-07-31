using Application.Adapters;
using Domain.Entidades;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class EnderecoService(IEnderecoRepository enderecoRepository) : IEnderecoService
{
    public async Task AddAsync(List<EnderecoModel> enderecos)
    {
        var domain = EnderecoAdapter.Map(enderecos);

        await enderecoRepository.AddAsync(domain);
    }

    public async Task AtualizarDados(EnderecoModel endereco)
    {
        var domain = await enderecoRepository.ObterPorIdAsync(endereco.Id);

        VerificarEnderecoNulo(domain); 

        domain!.Logradouro = endereco.Logradouro;
        domain.Bairro = endereco.Bairro;
        domain.UF = endereco.UF;
        domain.Status = Domain.Enums.EnumStatus.Finalizado;

        await enderecoRepository.AtualizarDados(domain);

    }

    public async Task<EnderecoModel> ObterCEPParaTratamento(string robo)
    {
        var domain = await enderecoRepository.ObterCEPParaTratamentoAsync(robo);

        VerificarEnderecoNulo(domain);

        domain!.Status = Domain.Enums.EnumStatus.EmAndamento;
        domain.Robo = robo;

        await enderecoRepository.AtualizarDados(domain);

        return EnderecoAdapter.Map(domain);
    }

    private void VerificarEnderecoNulo(Endereco? endereco)
    {
        if(endereco == null)
            throw new Exception("CEP não localizado");
    }

    public async Task<List<EnderecoModel>> ObterTodos()
    {
        var enderecos = await enderecoRepository.ObterTodosAsync();
        return EnderecoAdapter.Map(enderecos);
    }
}
