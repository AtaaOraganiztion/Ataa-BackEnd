using FluentValidation;

namespace Application.Features.Statics.Queries.GetById;

public class GetStaticsByIdQueryValidator : AbstractValidator<GetStaticsByIdQuery>
{
    public GetStaticsByIdQueryValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty();
    }
    
}