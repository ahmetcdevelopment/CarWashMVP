using NArchitecture.Core.Application.Responses;

namespace Application.Features.Comments.Commands.Update;

public class UpdatedCommentResponse : IResponse
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