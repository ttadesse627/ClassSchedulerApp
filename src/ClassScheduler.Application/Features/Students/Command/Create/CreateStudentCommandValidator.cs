using ClassScheduler.Application.Features.Students.Command.Create;
using FluentValidation;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator(CreateStudentCommand request)
    {
        Console.WriteLine("validating...");
    }
}