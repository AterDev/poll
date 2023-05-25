using Core.Entities.SystemEntities;
namespace Share.Models.RolePermissionDtos;
/// <summary>
/// 角色权限中间添加时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.SystemEntities.RolePermission"/>
public class RolePermissionAddDto
{
    public Guid RoleId { get; set; }
    public Guid PermissionId { get; set; }
    /// <summary>
    /// 权限类型
    /// </summary>
    public PermissionType PermissionTypeMyProperty { get; set; } = PermissionType.Write;
    public required Guid SystemRoleId { get; set; }
    public required Guid SystemPermissionId { get; set; }
    
}
