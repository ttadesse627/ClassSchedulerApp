using ClassScheduler.Application.Contracts.ResponseDtos.RoleDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Roles.Query;
public record GetRolesQuery : IRequest<List<RoleDto>> { }
public class GetRolesQueryHandler(IRoleRepository roleRepository) : IRequestHandler<GetRolesQuery, List<RoleDto>>
{
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<List<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        List<RoleDto> roleDtos = [];
        var roles = await _roleRepository.GetAllAsync();
        if (roles.Count != 0)
        {
            roleDtos.AddRange(roles.Select(role => new RoleDto
            {
                Id = Guid.Parse(role.Id),
                Name = role.Name,
            }));
        }

        return roleDtos;
    }
}
