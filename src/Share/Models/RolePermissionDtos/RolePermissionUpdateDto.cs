using Core.Entities.SystemEntities;
namespace Share.Models.RolePermissionDtos;
/// <summary>
/// 角色权限中间更新时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.SystemEntities.RolePermission"/>
public class RolePermissionUpdateDto
{
    public Guid? RoleId { get; set; }
    public Guid? PermissionId { get; set; }
    /// <summary>
    /// 权限类型
    /// </summary>
    public PermissionType? PermissionTypeMyProperty { get; set; }
    public Guid SystemRoleId { get; set; } = default!;
    public Guid SystemPermissionId { get; set; } = default!;
    
}
