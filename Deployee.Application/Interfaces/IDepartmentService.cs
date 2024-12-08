using Deployee.Domain.Common;
using Deployee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Application.Interfaces;

public interface IDepartmentService
{
    Task<Result<bool>> CreateDepartmentAsync(Department department,CancellationToken cancellationToken);

    Task<Result<List<Department>>> GetAllDepartmentsAsync(CancellationToken cancellationToken);

    Task<Result<Department>> GetDepartmentByIdAsync(int departmentId, CancellationToken cancellationToken);

    Task<Result<bool>> UpdateDepartmentAsync(Department department, CancellationToken cancellationToken);

    Task<Result<bool>> DeleteDepartmentAsync(int departmentId, CancellationToken cancellationToken);
}
