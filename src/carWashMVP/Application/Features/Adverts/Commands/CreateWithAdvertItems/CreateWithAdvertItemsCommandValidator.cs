using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Adverts.Commands.CreateWithAdvertItems;
public class CreateWithAdvertItemsCommandValidator : AbstractValidator<CreateWithAdvertItemsCommand>
{
    public CreateWithAdvertItemsCommandValidator()
    {
        RuleFor(c => c.TenantId).NotEmpty();
        RuleFor(c => c.WasherCarId).NotEmpty();
        RuleFor(c => c.Enlem).NotEmpty();
        RuleFor(c => c.Boylam).NotEmpty();
        RuleFor(c => c.Range).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.PricePerDistance).NotEmpty();
        RuleFor(c => c.MinOrderAmount).NotEmpty();
    }
}
