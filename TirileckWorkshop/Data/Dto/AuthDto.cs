using FluentValidation;

namespace TirileckWorkshop.Data.Dto;

public class AuthDto
{
    public string Login { get; set; }

    public string Password { get; set; }
}

public static class AuthDtoExtensions
{
    public class AuthDtoValidator : AbstractValidator<AuthDto>
    {
        public AuthDtoValidator()
        {
            RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage("Введите логин!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Введите пароль!")
                .Length(8, 64)
                .WithMessage("Пароль должен содержать минимум 8 символов");
        }
    }
} 