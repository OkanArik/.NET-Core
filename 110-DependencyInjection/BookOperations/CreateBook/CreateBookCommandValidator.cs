using System;
using FluentValidation;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>//AbstractValidator<CreateBookCommand> bununla beraber CreatBookCommandValidator'ı bir validation class haline getirdik ve bu validation class'ının CreateBookCommand class'ının nesnelerini validate ettiğini söyledik.
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command=> command.Model.GenreId).GreaterThan(0);//GenreId'nin dan büyük olma kuralını koyduk.
            RuleFor(command=> command.Model.PageCount).GreaterThan(0);//PageCount'un dan büyük olma kuralını koyduk.
            RuleFor(command=> command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);//PublishDate 'in boş olmaması ve kodun çalıştığı andaki tarihten önce olması kuralını koyduk.
            RuleFor(command=> command.Model.Title).MinimumLength(4);//Title'in en az 4 karakter olması kuralını koyduk.

        }
    }
}