using breaking_bad.domain.Entities;
using FluentValidation;

namespace breaking_bad.application.Validations
{
    public class EpoisodeValidation : AbstractValidator<Episode>
    {
        public EpoisodeValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(5)
                .WithMessage("Name must be longer than 5 episodes");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Description is required")
                .MinimumLength(20)
                .WithMessage("Description must be longer than 20 episodes");

            RuleFor(x => x.SeasonId)
                .NotEmpty()
                .WithMessage("The Id Season is required")
                .GreaterThan(0)
                .WithMessage("The Id Season is required");

            RuleFor(x => x.AirDate)
                .NotEmpty()
                .WithMessage("AirDate is required");

            RuleFor(x => x.Characters)
                .NotNull()
                .WithMessage("Characters list cannot be null.")
                .Must(characters => characters.Any())
                .WithMessage("There must be at least one episodes.");
        }
    }
}
