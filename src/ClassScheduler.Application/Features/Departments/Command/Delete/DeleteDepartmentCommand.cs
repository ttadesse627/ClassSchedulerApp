using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ErrorOr;
using MediatR;

namespace ClassScheduler.Application.Features.Departments.Command.Delete;
public record DeleteDepartmentCommand(Guid Id) : IRequest<ErrorOr<ServiceResponse<int>>> { }

public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, ErrorOr<ServiceResponse<int>>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    public async Task<ErrorOr<ServiceResponse<int>>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<int>();

        var departmentEntity = await _departmentRepository.GetAsync(request.Id);
        if (departmentEntity is null)
        {
            response.Message = $"Could not find a department with an id {request.Id}";
        }
        else
        {
            response.Success = await _departmentRepository.DeleteAsync(departmentEntity);
            if (response.Success)
            {
                response.Data = 1;
                response.Message = "Successfully deleted a department!";
            }

            else response.Errors!.Add("Could not delete department entity");
        }

        return response;
    }
}