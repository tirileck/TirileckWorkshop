using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using FluentValidation;

namespace TirileckWorkshop.Data.Dto;

public class AddOrderShortDto
{
    [Required]
    [MinLength(1)]
    public string FIO { get; set; }

    [Required]
    [MinLength(1)]
    public string Email { get; set; }

    [Required]
    [MinLength(1)]
    public string PhoneNumber { get; set; }

    [Required]
    [MinLength(1)]
    public string Description { get; set; }

    public string DeviceName { get; set; }

    public long? DeviceTypeId { get; set; }

    [Required]
    public long? WorkshopId { get; set; }
}

public static class AddOrderShortDtoExtensions
{
    public class AddOrderShortStoValidator : AbstractValidator<AddOrderShortDto>
    {
        public AddOrderShortStoValidator()
        {
            RuleFor(x => x.FIO)
                .NotEmpty()
                .WithMessage("Введите ФИО");
            
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Введите Email")
                .EmailAddress()
                .WithMessage("Введите корректный Email");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Введите телефон");

            RuleFor(x => x.WorkshopId)
                .NotNull()
                .WithMessage("Выберите предприятие")
                .GreaterThan(0)
                .WithMessage("Выберите предприятие");

            RuleFor(x => x.DeviceTypeId)
                .NotNull()
                .WithMessage("Выберите тип устройства")
                .GreaterThan(0)
                .WithMessage("Выберите тип устройства");

            When(x => x.DeviceTypeId is 1, () =>
            {
                RuleFor(x => x.DeviceName)
                    .NotEmpty()
                    .WithMessage("Введите свой тип");
            });

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Введите описание проблемы");
            
        }
    }
}