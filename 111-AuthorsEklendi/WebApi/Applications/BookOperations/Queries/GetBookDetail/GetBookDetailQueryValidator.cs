using FluentValidation;


namespace WebApi.Applications.BookOperations.Queries.GetBookDetail
{
    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(Query=> Query.BookId).GreaterThan(0);
        }
    }
}