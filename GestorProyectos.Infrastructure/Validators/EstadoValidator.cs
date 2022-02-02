using FluentValidation;
using GestorProyectos.Core.DTOs;

namespace GestorProyectos.Infrastructure.Validators
{
    public class EstadoValidator : AbstractValidator<EstadosDto>
    {
        public EstadoValidator()
        {
            RuleFor(estado => estado.Nombre)
                .NotNull()
                .WithMessage("Debe ingresar el Nombre del Estado.");

            RuleFor(estado => estado.Nombre)
                .Length(0, 100)
                .WithMessage("La longitud del Nombre menor o igual a 100 caracteres.");

            RuleFor(estado => estado.Orden)
                .NotNull()
                .WithMessage("Debe ingresar el Orden del Estado.");
        }
    }
}