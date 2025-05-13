using ClassScheduler.Application.Contracts.RequestDtos.RoleRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MediatR;

namespace ClassScheduler.Application.Features.Roles.Commands;
public class UpdateRoleCommand : IRequest<ServiceResponse<int>>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ICollection<PermissionRequest> Permissions { get; set; } = [];
}

public class UpdateRoleCommandHandler(IRoleRepository roleRepository) : IRequestHandler<UpdateRoleCommand, ServiceResponse<int>>
{
    private readonly IRoleRepository _roleRepository = roleRepository;
    public async Task<ServiceResponse<int>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();
        if (request.Id != Guid.Empty)
        {
            var role = await _roleRepository.GetAsync(request.Id);
            ICollection<Permission> permissions = [];

            if (request.Permissions.Count > 0)
            {
                foreach (var permission in request.Permissions)
                {
                    permissions.Add(new Permission { Name = permission.Name, Actions = permission.Actions });
                }
            }

            if (role is not null)
            {
                role.Name = request.Name;
                role.Permissions = permissions;
            }

            var resp = await _roleRepository.SaveChangesAsync(cancellationToken);
            if (resp > 0)
            {
                response.Data = 1;
                response.Message = "Successfully updated the role!";
                response.Success = true;
            }
        }

        return response;
    }
}