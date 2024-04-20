using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdvertItems.Commands.Delete;

public class DeletedAdvertItemResponse : IResponse
{
    public Guid Id { get; set; }
}