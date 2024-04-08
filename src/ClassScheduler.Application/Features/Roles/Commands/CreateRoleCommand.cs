using ClassScheduler.Application.Contracts.RequestDtos.RoleRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Roles;
public record CreateRoleCommand(CreateRoleRequest RoleRequest) : IRequest<ServiceResponse<int>> { }
public class CreateRoleCommandHandler(IRoleRepository roleRepository, IMapper mapper) : IRequestHandler<CreateRoleCommand, ServiceResponse<int>>
{
    private readonly IRoleRepository _roleRepository = roleRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ServiceResponse<int>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();
        if (request.RoleRequest is not null)
        {
            if (!string.IsNullOrEmpty(request.RoleRequest.Name))
            {
                var roleEntity = new Role(Guid.NewGuid(), request.RoleRequest.Name)
                {
                    Permissions = _mapper.Map<List<Permission>>(request.RoleRequest.Permissions),
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
        }

        return response;
    }
}