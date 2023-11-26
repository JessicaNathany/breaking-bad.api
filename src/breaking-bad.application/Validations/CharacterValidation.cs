using breaking_bad.domain.Entities;
using FluentValidation;

namespace breaking_bad.application.Validations
{
    public class CharacterValidation : AbstractValidator<Character>
    {
        public CharacterValidation()
        {
                RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .MinimumLength(10)
                .WithMessage("Name must be longer than 10 characters");

            RuleFor(x => x.Job)
                .NotEmpty()
                .WithMessage("Job is required");

            RuleFor(x => x.Gender)
                .NotEmpty()
                .WithMessage("Gender is required");

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage("ImageUrl is required");

            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("Status is required");

            RuleFor(x => x.NameActor)
                .NotEmpty()
                .WithMessage("NameActor is required");
        }
    }
}
