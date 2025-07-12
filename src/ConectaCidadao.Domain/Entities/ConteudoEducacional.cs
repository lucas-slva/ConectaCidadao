namespace ConectaCidadao.Domain.Entities;

public class ConteudoEducacional
{
    public Guid Id { get; set; }

    public string Titulo { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public string Descricao { get; set; } = string.Empty;

    public string Categoria { get; set; } = string.Empty;

    public DateTime DataCriacao { get; set; }
}