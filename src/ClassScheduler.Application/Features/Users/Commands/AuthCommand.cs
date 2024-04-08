using ClassScheduler.Application.Contracts.ResponseDtos.AuthResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Users.Commands;
public record AuthCommand : IRequest<AuthResponseDto>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class AuthCommandHandler(ITokenProviderService tokenProvider, IUserRepository userRepository, IPermissionRepository permissionRepository) : IRequestHandler<AuthCommand, AuthResponseDto>
{
    private readonly ITokenProviderService _tokenProvider = tokenProvider;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IPermissionRepository _permissionRepository = permissionRepository;
    public async Task<AuthResponseDto> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        var (result, roles, userId) = await _userRepository.AuthenticateUser(request.Username, request.Password);
        if (result.Succeeded)
        {
            
        }
        return new AuthResponseDto
        {
            Username = ""
        };
    }
}
