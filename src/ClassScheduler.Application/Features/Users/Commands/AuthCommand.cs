using ClassScheduler.Application.Contracts.ResponseDtos.AuthResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Users.Commands;
public record AuthCommand : IRequest<AuthResponseDto?>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class AuthCommandHandler(ITokenProviderService tokenProvider, IUserRepository userRepository) : IRequestHandler<AuthCommand, AuthResponseDto?>
{
    private readonly ITokenProviderService _tokenProvider = tokenProvider;
    private readonly IUserRepository _userRepository = userRepository;
    public async Task<AuthResponseDto?> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        var response = new AuthResponseDto();
        var (result, user) = await _userRepository.AuthenticateUser(request.Username, request.Password);
        if (result.Succeeded && user is not null)
        {
            response.Id = user.Id;
            response.FullName = user.PersonInfo?.FirstName + user.PersonInfo?.MiddleName + user.PersonInfo?.LastName;
            response.Username = user.UserName;
            response.Token = await _tokenProvider.GenerateJWTTokenAsync(user);

            return response;

        }

        return null;

    }
}
