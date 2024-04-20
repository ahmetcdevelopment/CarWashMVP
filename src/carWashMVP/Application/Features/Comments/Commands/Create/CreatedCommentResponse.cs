using NArchitecture.Core.Application.Responses;

namespace Application.Features.Comments.Commands.Create;

public class CreatedCommentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid AdvertId { get; set; }
    public Guid ParentId { get; set; }
    public int Rating { get; set; }
    public int UserId { get; set; }
    public int BrandSerialId { get; set; }
    public string Content { get; set; }
}