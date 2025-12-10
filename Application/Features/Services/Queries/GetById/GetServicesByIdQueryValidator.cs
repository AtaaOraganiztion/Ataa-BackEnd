using FluentValidation;

namespace Application.Features.Services.Queries.GetById;

public class GetServicesByIdQueryValidator : AbstractValidator<GetServicesByIdQuery>
{
    public GetServicesByIdQueryValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty();
    }
    
}