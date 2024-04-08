using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Instructors.Command.Delete;
public record DeleteInstructorCommand(Guid Id) : IRequest<ServiceResponse<int>> { }

public class DeleteInstructorCommandHandler : IRequestHandler<DeleteInstructorCommand, ServiceResponse<int>>
{
    private readonly IInstructorRepository _instructorRepository;

    public DeleteInstructorCommandHandler(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }
    public async Task<ServiceResponse<int>> Handle(DeleteInstructorCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();

        var instructorEntity = await _instructorRepository.GetAsync(request.Id);
        if (instructorEntity is null)
        {
            response.Message = $"Could not find a instructor with an id {request.Id}";
        }
        else
        {
            response.Success = await _instructorRepository.DeleteAsync(instructorEntity);
            if (response.Success)
            {
                response.Data = 1;
                response.Message = "Successfully deleted a instructor!";
            }

            else response.Errors.Add("Could not delete Instructor entity");
        }

        return response;
    }
}