using FluentValidation;

namespace CleanArchWithCORSandMediator.Application.Blogs.Commands.CreateBlogPost
{
    class CreateBlogPostCommandValidator : AbstractValidator<CreateBlogPostCommand>
    {
        public CreateBlogPostCommandValidator()
        {
            RuleFor(v => v.Title)
           .NotEmpty().WithMessage("Title is required.");

            RuleFor(v => v.Auther)
                .NotEmpty().WithMessage("Auther is required");
        }
    }
}
