using NArchitecture.Core.Application.Responses;

namespace Application.Features.BrandSerials.Commands.Delete;

public class DeletedBrandSerialResponse : IResponse
{
    public Guid Id { get; set; }
}