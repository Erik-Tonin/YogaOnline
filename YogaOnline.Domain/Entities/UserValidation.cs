using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaOnline.Domain.Entities
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            //RuleFor(c => c.Id)
            //    .NotEqual(Guid.Empty);

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome tem que ser preenchido")
                .Length(0, 100).WithMessage("Tamanho do campo nome excedido");

            //RuleFor(c => c.LastName)
            //    .NotEmpty().WithMessage("Sobrenome tem que ser preenchido")
            //    .Length(0, 100).WithMessage("Tamanho do campo sobrenome excedido");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email tem que ser preenchido")
                .Length(0, 80).WithMessage("Tamanho do campo email excedido");


            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Senha tem que ser preenchido")
                .Length(10, 150).WithMessage("Tamanho do campo senha excedido");

            RuleFor(c => c.ConfirmPassword)
                .NotEmpty().WithMessage("Senha tem que ser preenchido")
                .Length(10, 150).WithMessage("Tamanho do campo senha excedido");

            //RuleFor(c => c.ImageURL)
            //    .Length(0, 250).WithMessage("Tamanho do campo url da imagem excedido");

            //RuleFor(c => c.AdditionalComments)
            //    .Length(1, 500).When(x => x.AdditionalComments != null).WithMessage("Tamanho do campo comentários adicionais excedido");
        }
    }
}
