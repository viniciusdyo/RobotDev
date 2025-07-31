using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure;

public class RobotDevDbContext : DbContext
{
    public DbSet<Endereco> Enderecos { get; set; }
    public RobotDevDbContext(DbContextOptions options) : base(options) { }
}
