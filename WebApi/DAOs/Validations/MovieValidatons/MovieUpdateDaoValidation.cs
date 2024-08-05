using FluentValidation;
using WebApi.DAOs.MovieDaos;

namespace WebApi.DTOs.Validations;
public class MovieUpdateDaoValidation : AbstractValidator<MovieUpdateDao>
{
    public MovieUpdateDaoValidation()
    {
        When(x => x == null, () =>
        {
            RuleFor(x => x).NotNull();
        }).Otherwise(() =>
        {
            RuleFor(movie => movie.Id).NotEmpty().WithMessage("Id is required");

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required")
            .Length(1, 1000).WithMessage("The name must be between 1 and 1000 characters.");

            RuleFor(movie => movie.DatePublication).NotEmpty().WithMessage("Date of publication is required");
        });
    }
}
