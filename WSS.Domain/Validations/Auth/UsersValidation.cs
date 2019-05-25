using FluentValidation;
using WSS.Domain.Models.Auth;

namespace WSS.Domain.Validations
{
    public class UsuariosValidation : AbstractValidator<Users>
    {
        public UsuariosValidation()
        {
            RuleFor(x => x.User)
                .NotEmpty()
                .WithMessage("El campo Usuario es necesario");
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El campo Nombre es necesario");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("El campo Apellido es necesario");
        }
    }
}
