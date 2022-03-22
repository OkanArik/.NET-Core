using System;
using FluentValidation;

namespace WebApi.Applications.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command=> command.Model.Name.Trim()).NotEmpty().MinimumLength(4);
            RuleFor(command=> command.Model.SurName.Trim()).NotEmpty().MinimumLength(3);
            RuleFor(command=> command.Model.dateOfBirth.Date).NotEmpty().LessThan(DateTime.Now.Date.AddYears(-10));
        }
    }
}