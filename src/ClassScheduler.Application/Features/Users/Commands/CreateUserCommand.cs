using ClassScheduler.Application.Contracts.RequestDtos.UserRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ClassScheduler.Application.Features.Users.Commands;
public record CreateUserCommand(CreateUserRequest UserRequest) : IRequest<ServiceResponse<int>> { }
public class CreateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository, UserManager<User> userManager) : IRequestHandler<CreateUserCommand, ServiceResponse<int>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IRoleRepository _roleRepository = roleRepository;
    private readonly UserManager<User> _userManager = userManager;

    public async Task<ServiceResponse<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();
        if (request.UserRequest is not null)
        {
            if (!string.IsNullOrEmpty(request.UserRequest.Username?.Trim()) || !string.IsNullOrEmpty(request.UserRequest.Password.Trim()))
            {
                Person? Person = null;
                if (request.UserRequest.Person is not null)
                {
                    Person = new Person
                    {
                        FirstName = request.UserRequest.Person.FirstName,
                        MiddleName = request.UserRequest.Person.MiddleName,
                        LastName = request.UserRequest.Person.LastName,
                        BirthDate = request.UserRequest.Person.BirthDate,
                    };
                }

                var roles = await _roleRepository.GetRolesAsync(request.UserRequest.RoleIds);
                var userEntity = new User
                {
                    UserName = request.UserRequest.Username,
                    Email = request.UserRequest.Email,
                    Person = Person,
                    Roles = roles
                };

                IdentityResult? identityResult = null;
                try
                {
                    identityResult = await _userManager.CreateAsync(userEntity, request.UserRequest.Password);
                    if (identityResult.Succeeded)
                    {
                        response.Data = 1;
                        response.Message = "Successfully created a user!";
                        response.Success = identityResult.Succeeded;
                    }
                    else
                    {
                        response.Message = identityResult.Errors.Select(error => error.Description).First();
                        response.Errors.AddRange(identityResult.Errors.Select(error => error.Code));
                    }
                }
                catch (Exception)
                {
                    response.Message = "Could not create a user!";
                    response.Errors.AddRange(identityResult!.Errors.Select(err => err.Code));
                    throw;
                }
            }
            else
            {
                response.Message = "The user's username should not be null or empty!";
                response.Errors.Add(response.Message);
                throw new Exception("The user's username should not be null or empty!");
            }
        }

        return response;
    }
}