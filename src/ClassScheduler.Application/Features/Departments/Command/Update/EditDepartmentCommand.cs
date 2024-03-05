using ClassScheduler.Application.Contracts.RequestDtos.DepartmentRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Departments.Command.Update;
public record EditDepartmentCommand(EditDepartmentRequestDto DepartmentRequestDto) : IRequest<ServiceResponse<string>> { }
public class EditDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper) : IRequestHandler<EditDepartmentCommand, ServiceResponse<string>>
{
    private readonly IDepartmentRepository _departmentRepository = departmentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<ServiceResponse<string>> Handle(EditDepartmentCommand command, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<string>();
        if (command.DepartmentRequestDto is null)
        {
            response.Success = false;
            response.Data = "Invalid Operation";
            response.Errors!.Add("The department edit payload should not be null");
            response.Message = "There should be a department data to edit";
        }
        else if (command.DepartmentRequestDto.Id == Guid.Empty)
        {
            response.Success = false;
            response.Data = "Invalid Operation";
            response.Errors!.Add("The department to be edited should have a valid Id");
            response.Message = "The department id should not be empty to edit";
        }
        else
        {
            // Department departmentEntity = await _departmentRepository.GetAsync(command.DepartmentRequestDto.Id);
            // if (departmentEntity is not null)
            // {
            var departmentEntity = _mapper.Map<Department>(command.DepartmentRequestDto);
            response.Success = await _departmentRepository.UpdateAsync(departmentEntity);
            if (response.Success)
            {
                response.Success = true;
                response.Data = "Operation Succeed";
                response.Message = "You've successfully edited";
            }
            // }
        }
        return response;
    }
}
