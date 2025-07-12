using ConectaCidadao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConectaCidadao.Application.Interfaces;

public interface IAppDbContext
{
    DbSet<ConteudoEducacional> ConteudosEducacionais { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}