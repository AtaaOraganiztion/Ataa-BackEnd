using FluentValidation;

namespace Application.Features.Features.Queries.GetById;

public class GetFeaturesByIdQueryValidator : AbstractValidator<GetFeaturesByIdQuery>
{
    public GetFeaturesByIdQueryValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty();
    }
    
}