using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;

namespace ClassScheduler.Application.Features.Users.Commands;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly CreateUserCommand _command;
    private readonly UserManager<User> _userManager;


    public CreateUserCommandValidator(IUserRepository userRepository, UserManager<User> userManager, IMapper mapper, CreateUserCommand command)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _mapper = mapper;
        _command = command;
        RuleFor(userCommand => userCommand.UserRequest.Email)
            .MustAsync((email, token) => IsEmailUnique(email!, token));
    }

    private async Task<bool> IsEmailUnique(string email, CancellationToken token)
    {
        var user = _mapper.Map<User>(_command.UserRequest);
        var em = await _userManager.GetEmailAsync(user);

        return em is null ? true : false;
    }
}