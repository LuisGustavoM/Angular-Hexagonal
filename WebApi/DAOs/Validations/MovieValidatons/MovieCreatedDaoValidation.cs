using FluentValidation;
using WebApi.DAOs.MovieDaos;

namespace WebApi.DTOs.Validations;
public class MovieCreatedDaoValidation : AbstractValidator<MovieCreatedDao>
{
    public MovieCreatedDaoValidation()
    {
        When(x => x == null, () =>
        {
            RuleFor(x => x).NotNull();
        }).Otherwise(() =>
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required")
            .Length(1, 1000).WithMessage("The name must be between 1 and 1000 characters.");

            RuleFor(movie => movie.DatePublication).NotEmpty().WithMessage("Date of publication is required");
        });
    }
}
