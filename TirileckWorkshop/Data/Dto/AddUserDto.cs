using FluentValidation;

namespace TirileckWorkshop.Data.Dto;

public class AddUserDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string MiddleName { get; set; }

    public string Position { get; set; }
    
    public string PhoneNumber { get; set; }

    public string Email { get; set; }
}

public static class AddUserDtoExtensions
{
    public class AddUserDtoValidator : AbstractValidator<AddUserDto>
    {
        public AddUserDtoValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Введите имя!");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Введите фамилию!");
            RuleFor(x => x.MiddleName)
                .NotEmpty()
                .WithMessage("Введите отчество!");
            RuleFor(x => x.Position)
                .NotEmpty()
                .WithMessage("Введите должность!");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Введите Email!")
                .EmailAddress()
                .WithMessage("Некорректный Email!");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Введите телефон!");
        }
    }
}