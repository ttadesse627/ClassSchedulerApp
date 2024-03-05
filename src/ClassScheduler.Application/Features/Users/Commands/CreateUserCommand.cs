using ClassScheduler.Application.Contracts.RequestDtos.UserRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MediatR;

namespace ClassScheduler.Application.Features.Users.Commands;
public record CreateUserCommand(CreateUserRequest UserRequest) : IRequest<ServiceResponse<int>> { }
public class CreateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository) : IRequestHandler<CreateUserCommand, ServiceResponse<int>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IRoleRepository _roleRepository = roleRepository;

    public async Task<ServiceResponse<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();
        if (request.UserRequest is not null)
        {
            if (!string.IsNullOrEmpty(request.UserRequest.Username))
            {
                PersonInfo? personInfo = null;
                if (request.UserRequest.PersonInfo is not null)
                {
                    personInfo = new PersonInfo
                    {
                        FirstName = request.UserRequest.PersonInfo.FirstName,
                        MiddleName = request.UserRequest.PersonInfo.MiddleName,
                        LastName = request.UserRequest.PersonInfo.LastName,
                        BirthDate = request.UserRequest.PersonInfo.BirthDate,
                    };
                }
                // var userEntity = new User
                // {
                //     Id = Guid.NewGuid().ToString(),
                //     UserName = request.UserRequest.Username,
                //     Email = request.UserRequest.Email
                // };
                // var resp = await _roleRepository.CreateRoleAsync(role: roleEntity);
                // response.Data = resp.Data;
                // response.Message = resp.Message;
                // response.Errors = resp.Errors;
                // response.Success = resp.Success;

            }
            else
            {
                response.Message = "The user's username should not be null or empty!";
                response.Errors.Add(response.Message);
            }
        }

        return response;
    }
}