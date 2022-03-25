
using FuncionarioApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuncionarioApi.Data
{
    public class FuncionarioDbContext : DbContext
    {
        public FuncionarioDbContext(DbContextOptions<FuncionarioDbContext> options) : base(options) { }

        public DbSet<FuncionarioEntity> Funcionarios { get; set; } = null!;

    }
}