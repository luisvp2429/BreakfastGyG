using BreakfastGyG.Contracts.Breakfast;
using FluentValidation;

namespace BreakfastGyG.Validations;

public class CreateBreakfastRequestValidator : AbstractValidator<CreateBreakfastRequest>
{
    public CreateBreakfastRequestValidator()
    {
        RuleFor(x=>x.Name).Length(3,50);
        RuleFor(x=>x.Name).NotEmpty();
        RuleFor(x=>x.Description).Length(50,150);
        RuleFor(x=>x.Description).NotEmpty();
        RuleFor(x=>x.StartDateTime).NotEmpty();
        RuleFor(x=>x.EndDateTime).NotEmpty();
    }
}

