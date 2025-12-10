using FluentValidation;

namespace Application.Features.Opinions.Queries.GetById;

public class GetOpinionsByIdQueryValidator : AbstractValidator<GetOpinionsByIdQuery>
{
    public GetOpinionsByIdQueryValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty();
    }
    
}