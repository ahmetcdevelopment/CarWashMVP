using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Comments.Queries.GetList;

public class GetListCommentListItemDto : IDto
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