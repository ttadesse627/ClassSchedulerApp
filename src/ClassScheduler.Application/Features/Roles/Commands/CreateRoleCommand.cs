using ClassScheduler.Application.Contracts.RequestDtos.RoleRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MediatR;

namespace ClassScheduler.Application.Features.Roles;
public record CreateRoleCommand : IRequest<ServiceResponse<int>>
{
    public required string Name { get; set; }
    public ICollection<PermissionRequest> Permissions { get; set; } = [];
}
public class CreateRoleCommandHandler(IRoleRepository roleRepository) : IRequestHandler<CreateRoleCommand, ServiceResponse<int>>
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<ServiceResponse<int>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();
        var permissions = new List<Permission>();
        if (!string.IsNullOrEmpty(request.Name))
        {
            if (request.Permissions.Count > 0)
            {
                foreach (var permission in request.Permissions)
                {
                    permissions.Add(new Permission { Name = permission.Name, Actions = permission.Actions });
                }
            }
            var roleEntity = new Role
            {
                Name = request.Name,
                Permissions = permissions
            };
            var resp = await _roleRepository.CreateRoleAsync(role: roleEntity, cancellationToken);
            response.Data = resp.Data;
            response.Message = resp.Message;
            response.Errors = resp.Errors;
            response.Success = resp.Success;

        }
        else
        {
            response.Message = "The role name should not be null or empty!";
            response.Errors.Add(response.Message);
        }

        return response;
    }
}