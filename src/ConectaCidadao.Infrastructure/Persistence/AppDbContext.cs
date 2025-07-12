using ConectaCidadao.Application.Interfaces;
using ConectaCidadao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConectaCidadao.Infrastructure.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ConteudoEducacional> ConteudosEducacionais => Set<ConteudoEducacional>();
}