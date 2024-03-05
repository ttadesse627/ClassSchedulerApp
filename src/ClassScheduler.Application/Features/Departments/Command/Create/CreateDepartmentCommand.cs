


using ClassScheduler.Application.Contracts.RequestDtos.DepartmentRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.DepartmentResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MapsterMapper;
using MediatR;

namespace ClassScheduler.Application.Features.Departments.Command.Create;
public record CreateDepartmentCommand(DepartmentRequestDto Department) : IRequest<ServiceResponse<DepartmentResponseDto>>{}
public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, ServiceResponse<DepartmentResponseDto>>
{
    private readonly IMapper _mapper;
    private readonly IDepartmentRepository _departmentRepository;

    public CreateDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository)
    {
        _mapper = mapper;
        _departmentRepository = departmentRepository;
    }
    public async Task<ServiceResponse<DepartmentResponseDto>> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        var response = new ServiceResponse<DepartmentResponseDto>();
        var departmentEntity = _mapper.Map<Department>(command.Department);
        var savedEntity = await _departmentRepository.CreateDepartmentAsync(departmentEntity);
        if (savedEntity != null)
        {
            var responseDto = _mapper.Map<DepartmentResponseDto>(savedEntity);
            response.Data = responseDto;
            response.Message = "Successfully saved a department!";
            response.Success = true;
        }

        return response;
    }
}