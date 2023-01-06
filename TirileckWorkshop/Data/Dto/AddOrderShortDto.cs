using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using FluentValidation;

namespace TirileckWorkshop.Data.Dto;

public class AddOrderShortDto
{
    public string FIO { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Description { get; set; }

    public string DeviceName { get; set; }
    
    public DeviceTypeDto? DeviceType { get; set; }
    
    public WorkshopDto? Workshop { get; set; }
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

            RuleFor(x => x.Workshop)
                .NotNull()
                .WithMessage("Выберите предприятие");

            RuleFor(x => x.DeviceType)
                .NotNull()
                .WithMessage("Выберите тип устройства");

            When(x => x.DeviceType is { Id: 1 }, () =>
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