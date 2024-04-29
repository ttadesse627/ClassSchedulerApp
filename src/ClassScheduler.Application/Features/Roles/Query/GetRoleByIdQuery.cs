using ClassScheduler.Application.Contracts.ResponseDtos.RoleDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Roles.Query;
public record GetRoleByIdQuery(Guid Id) : IRequest<RoleResponseDto> { }
public class GetRoleByIdQueryHandler(IRoleRepository roleRepository) : IRequestHandler<GetRoleByIdQuery, RoleResponseDto>
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<RoleResponseDto> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        RoleResponseDto roleDto = new();
        var role = await _roleRepository.GetAsync(request.Id);

        if (role is not null)
        {
            roleDto = new RoleResponseDto
            {
                Id = Guid.Parse(role.Id),
                Name = role.Name,
                Permissions = role.Permissions.Select(rp => new PermissionDto { Name = rp.Name, Actions = rp.Actions }).ToList()
            };
        }

        return roleDto;
    }
}
