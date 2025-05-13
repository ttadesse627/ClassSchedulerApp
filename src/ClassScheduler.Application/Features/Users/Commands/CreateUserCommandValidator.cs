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


    public CreateUserCommandValidator(IUserRepository userRepository, IMapper mapper, CreateUserCommand command)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _command = command;
        RuleFor(userCommand => userCommand.UserRequest.Email)
            .MustAsync((email, token) => IsEmailUnique(email, token));
    }

    private async Task<bool> IsEmailUnique(string email, CancellationToken token)
    {
        User? user = await _userRepository.GetByEmailAsync(email);
        if (user is not null)
        {
            return false;
        }
        return true;
    }
}