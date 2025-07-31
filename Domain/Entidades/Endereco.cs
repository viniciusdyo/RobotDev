using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entidades;

public class Endereco
{
    [Key]
    public int Id { get; set; }
    public string CEP { get; set; }
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public string? UF { get; set; }
    public EnumStatus Status { get; set; } = EnumStatus.Aberto;
    public string? Robo { get; set; }
}
