using NArchitecture.Core.Application.Responses;

namespace Application.Features.OrderWashers.Commands.Delete;

public class DeletedOrderWasherResponse : IResponse
{
    public Guid Id { get; set; }
}