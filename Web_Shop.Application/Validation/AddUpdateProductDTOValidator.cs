using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Shop.Application.DTOs;

namespace Web_Shop.Application.Validation
{
    public class AddUpdateProductDTOValidator : AbstractValidator<AddUpdateProductDTO>
{
    public AddUpdateProductDTOValidator()
    {
            RuleFor(request => request.Name)
                .Length(3, 75)
                .WithMessage("Pole 'Nazwa produktu' musi zawierać co najmniej {MinLength} i maksymalnie {MaxLength} znaków.");

            RuleFor(request => request.Description)
                .Length(20, 1000)
                .WithMessage("Opis musi mieć długość od {MinLength} do {MaxLength} znaków, aby był wystarczająco szczegółowy.");

            RuleFor(request => request.Price)
                .NotNull()
                .WithMessage("Należy podać cenę produktu.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Cena produktu nie może być wartością ujemną.");

            RuleFor(request => request.Sku)
                .NotEmpty().WithMessage("Pole 'Kod produktu (SKU)' jest wymagane i nie może być puste.")
                .Matches("^[A-Z]{3}-[A-Z]{2}-[A-Z0-9]{4,}$")
                .WithMessage("Pole 'Kod produktu (SKU)' musi być w formacie 'XXX-YY-ZZZZ...' (np. ELE-SM-PUL001).");
        }
}
}