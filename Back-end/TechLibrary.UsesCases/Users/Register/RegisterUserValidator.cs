using FluentValidation;
using TechLibrary.Communication.Requests;

namespace TechLibrary.UsesCases.Users.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestUserJson>
    {
        public RegisterUserValidator()
        {
            RuleFor(request => request.Name).NotEmpty().WithMessage("Nome não pode ficar em branco!");
            RuleFor(request => request.Email).EmailAddress().WithMessage("E-mail inválido.");
            RuleFor(request => request.Password).NotEmpty().WithMessage("A senha é obrigatória!");
            When(request => string.IsNullOrEmpty(request.Password) == false, SenhaNulaOuVazia);
        }
            public void SenhaNulaOuVazia()
            {
                RuleFor(request => request.Password.Length).GreaterThanOrEqualTo(8).WithMessage($"Senha deve ter mais que 6 caracteres.");
            }
    }
}
