using Domain.Entidades;
using Domain.Models;

namespace Application.Adapters;

public static class EnderecoAdapter
{
    public static EnderecoModel Map(Endereco endereco)
    {
        var model = new EnderecoModel();
        model.Id = endereco.Id;
        model.CEP = endereco.CEP;
        model.Logradouro = endereco.Logradouro;
        model.UF = endereco.UF;
        model.Bairro = endereco.Bairro;
        return model;
    }

    public static Endereco Map(EnderecoModel enderecoModel)
    {
        var entidade = new Endereco();
        entidade.Id = enderecoModel.Id;
        entidade.CEP = enderecoModel.CEP;
        entidade.Logradouro = enderecoModel.Logradouro;
        entidade.UF = enderecoModel.UF;
        entidade.Bairro = enderecoModel.Bairro;
        return entidade;
    }

    public static List<EnderecoModel> Map(List<Endereco> endereco)
    {
        return endereco.Select(Map).ToList();
    }
    public static List<Endereco> Map(List<EnderecoModel> endereco)
    {
        return endereco.Select(Map).ToList();
    }


}
