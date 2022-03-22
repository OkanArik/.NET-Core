using System;
using FluentValidation;

namespace Webapi.Applications.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command=> command.Model.Name.Trim()).NotEmpty().MinimumLength(4);
            RuleFor(command=> command.Model.SurName.Trim()).NotEmpty().MinimumLength(3);
            RuleFor(command=> command.Model.dateOfBirth.Date).NotEmpty().LessThan(DateTime.Now.Date.AddYears(-10));
        }
    }
}