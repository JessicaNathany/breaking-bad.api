using breaking_bad.domain.Entities;
using FluentValidation;

namespace breaking_bad.application.Validations
{
    public class SeasonValidation : AbstractValidator<Season>
    {
        public SeasonValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(5)
                .WithMessage("Name must be longer than 5 season");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MinimumLength(20)
                .WithMessage("Description must be longer than 20 season");

            RuleFor(x => x.AirDate)
                .NotEmpty()
                .WithMessage("AirDate is required");
        }
    }
}
