using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace ClassScheduler.Application.Features.Students.Command.Delete;
public record DeleteStudentCommand(Guid Id) : IRequest<ErrorOr<ServiceResponse<int>>> { }

public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, ErrorOr<ServiceResponse<int>>>
{
    private readonly IStudentRepository _studentRepository;

    public DeleteStudentCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<ErrorOr<ServiceResponse<int>>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();

        var studentEntity = await _studentRepository.GetAsync(request.Id);
        if (studentEntity is null)
        {
            response.Message = $"Could not find a student with an id {request.Id}";
        }
        else
        {
            response.Success = await _studentRepository.DeleteAsync(studentEntity);
            if (response.Success)
            {
                response.Data = 1;
                response.Message = "Successfully deleted a student!";
            }

            else response.Errors!.Add("Could not delete Stuent entity");
        }

        return response;
    }
}