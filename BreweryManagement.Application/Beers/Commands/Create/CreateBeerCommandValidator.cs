using FluentValidation;

namespace BreweryManagement.Application.Beers.Commands.Create
{
    public class CreateBeerCommandValidator : AbstractValidator<CreateBeerCommand>
    {
        public CreateBeerCommandValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

            RuleFor(x => x.BrewerId).NotNull();
        }
    }
}
