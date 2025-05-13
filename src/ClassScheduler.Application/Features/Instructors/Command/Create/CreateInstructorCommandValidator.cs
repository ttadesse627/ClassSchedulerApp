using ClassScheduler.Application.Features.Instructors.Command.Create;
using FluentValidation;

public class CreateInstructorCommandValidator : AbstractValidator<CreateInstructorCommand>
{
    public CreateInstructorCommandValidator(CreateInstructorCommand request)
    {
        Console.WriteLine("validating...");
    }
}