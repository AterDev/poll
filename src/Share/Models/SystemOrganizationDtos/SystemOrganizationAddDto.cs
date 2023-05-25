using Core.Entities.SystemEntities;
namespace Share.Models.SystemOrganizationDtos;
/// <summary>
/// 组织结构添加时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.SystemEntities.SystemOrganization"/>
public class SystemOrganizationAddDto
{
    /// <summary>
    /// 名称
    /// </summary>
    [MaxLength(100)]
    public required string Name { get; set; }
    public Guid? ParentId { get; set; }
    public List<Guid>? SystemOrganizationIds { get; set; }
    public Guid? SystemOrganizationId { get; set; }
    public List<Guid>? SystemUserIds { get; set; }
    
}
