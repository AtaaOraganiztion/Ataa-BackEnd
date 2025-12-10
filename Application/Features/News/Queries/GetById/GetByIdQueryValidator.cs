using FluentValidation;

namespace Application.Features.News.Queries.GetById;

public class GetByIdQueryValidator : AbstractValidator<GetNewsByIdQuery>
{
    public GetByIdQueryValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty();
    }
    
}