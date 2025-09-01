using ConectaCidadao.Application.Dtos;
using FluentValidation;

namespace ConectaCidadao.Application.Validators;

public class UpdateConteudoRequestValidator : AbstractValidator<UpdateConteudoRequest>
{
    public UpdateConteudoRequestValidator()
    {
        RuleFor(x => x.Titulo)
            .NotEmpty().WithMessage("Título é obrigatório.")
            .MaximumLength(200).WithMessage("Título deve ter no máximo 200 caracteres.");
    }
}