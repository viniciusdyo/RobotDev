using Domain.Entidades;
using Domain.Interfaces.Repository;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Repositories;

public class EnderecoRepository(RobotDevDbContext context) : IEnderecoRepository
{
    public async Task AddAsync(List<Endereco> enderecos)
    {
        await context.BulkInsertAsync(enderecos);
    }

    public async Task AtualizarDados(Endereco endereco)
    {
        context.Enderecos.Update(endereco);
        await context.SaveChangesAsync();
    }

    public async Task<Endereco?> ObterCEPParaTratamentoAsync(string robo)
    {
        var cepExistente = await context.Enderecos.Where(
        x => x.Status == Domain.Enums.EnumStatus.EmAndamento && x.Robo == robo).FirstOrDefaultAsync();

        if (cepExistente != null)
        {
            return cepExistente;
        }
        var cep = await context.Enderecos.Where(x => x.Status == Domain.Enums.EnumStatus.Aberto && string.IsNullOrEmpty(x.Robo)).FirstOrDefaultAsync();

        return cep;
    }

    public async Task<Endereco?> ObterPorIdAsync(int id)
    {
        return await context.Enderecos.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Endereco>> ObterTodosAsync()
    {
        return await context.Enderecos.ToListAsync();
    }
}
