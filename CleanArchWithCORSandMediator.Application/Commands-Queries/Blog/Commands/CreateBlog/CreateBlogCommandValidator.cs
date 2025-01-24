using FluentValidation;
namespace CleanArchWithCORSandMediator.Application.Features.Blog.Commands.CreateBlog
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(10).WithMessage("Name must not exceed 10 characters.");

            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Description is required");

            RuleFor(v => v.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MaximumLength(10).WithMessage("Name must not exceed 10 characters.");
        }
    }
}
