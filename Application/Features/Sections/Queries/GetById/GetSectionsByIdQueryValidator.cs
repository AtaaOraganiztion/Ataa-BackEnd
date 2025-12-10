using FluentValidation;

namespace Application.Features.Sections.Queries.GetById;

public class GetSectionsByIdQueryValidator : AbstractValidator<GetSectionsByIdQuery>
{
    public GetSectionsByIdQueryValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty();
    }
    
}