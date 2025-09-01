using ConectaCidadao.Domain.Entities;

namespace ConectaCidadao.Application.Interfaces;

public interface IConteudoRepository
{
    Task<List<ConteudoEducacional>> ListAsync(CancellationToken ct = default);
    Task<ConteudoEducacional?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<ConteudoEducacional> AddAsync(ConteudoEducacional entity, CancellationToken ct = default);
    Task UpdateAsync(ConteudoEducacional entity, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}