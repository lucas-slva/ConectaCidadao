using ConectaCidadao.Application.Interfaces;
using ConectaCidadao.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConectaCidadao.Infrastructure.Repositories;

public class ConteudoRepository(IAppDbContext db) : IConteudoRepository
{
    public Task<List<ConteudoEducacional>> ListAsync(CancellationToken ct = default) => db.ConteudosEducacionais.AsNoTracking().ToListAsync(ct);

    public Task<ConteudoEducacional?> GetByIdAsync(Guid id, CancellationToken ct = default) => db.ConteudosEducacionais.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task<ConteudoEducacional> AddAsync(ConteudoEducacional entity, CancellationToken ct = default)
    {
        db.ConteudosEducacionais.Add(entity);
        await db.SaveChangesAsync(ct);
        return entity;
    }

    public async Task UpdateAsync(ConteudoEducacional entity, CancellationToken ct = default)
    {
        db.ConteudosEducacionais.Update(entity);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var e = await db.ConteudosEducacionais.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (e is null) return;
        db.ConteudosEducacionais.Remove(e);
        await db.SaveChangesAsync(ct);
    }
}