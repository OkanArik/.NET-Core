using FluentValidation;

namespace WebApi.Applications.GenreOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(author=> author.AuthorId).GreaterThan(0);
        }
    }
}