using FluentValidation;

namespace Application.Features.ContactForm.Queries.GetById;

public class GetContactFormByIdQueryValidator : AbstractValidator<GetContactFormByIdQuery>
{
    public GetContactFormByIdQueryValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty();
    }
    
}