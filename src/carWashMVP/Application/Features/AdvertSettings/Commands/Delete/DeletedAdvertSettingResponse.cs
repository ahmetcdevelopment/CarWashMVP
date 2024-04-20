using NArchitecture.Core.Application.Responses;

namespace Application.Features.AdvertSettings.Commands.Delete;

public class DeletedAdvertSettingResponse : IResponse
{
    public Guid Id { get; set; }
}