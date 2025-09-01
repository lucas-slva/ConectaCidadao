using ConectaCidadao.Application.Dtos;
using FluentValidation;

namespace ConectaCidadao.Application.Validators;

public class CreateConteudoRequestValidator  : AbstractValidator<CreateConteudoRequest>
{
    public CreateConteudoRequestValidator()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("Título é obrigatório.")
            .MaximumLength(200).WithMessage("Título deve ter no máximo 200 caracteres.");

        RuleFor(x => x.Link)
            .Must(link => string.IsNullOrWhiteSpace(link) || Uri.IsWellFormedUriString(link, UriKind.Absolute))
            .WithMessage("Link inválido (use URL absoluta).");

        RuleForEach(x => x.Tags)
            .MaximumLength(30).WithMessage("Cada tag deve ter no máximo 30 caracteres.");

        RuleFor(x => x.Tags)
            .Must(tags => tags == null || tags.Distinct(StringComparer.OrdinalIgnoreCase).Count() == tags.Length)
            .WithMessage("Tags não devem se repetir.");
    }
}