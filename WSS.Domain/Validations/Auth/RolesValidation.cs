using FluentValidation;
using WSS.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSS.Domain.Validations
{
    public class RolesValidation : AbstractValidator<Roles>
    {
        public RolesValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El campo Nombre es necesario.");
            RuleFor(x => x.Permissions)
                .NotEmpty()
                .WithMessage("Seleccione al menos un permiso.");
        }
    }
}
