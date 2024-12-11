using Deployee.Application.Interfaces;
using Deployee.Domain.Common;
using Deployee.Domain.Entities;
using Deployee.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<DepartmentService> _logger;

    public DepartmentService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork, ILogger<DepartmentService> logger)
    {
        _departmentRepository = departmentRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Result<bool>> CreateDepartmentAsync(Department department, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Started creating a Department with Id: {DepartmentId}", department.Id);

            await _departmentRepository.InsertAsync(department, cancellationToken);
            var departmentCreated = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

            if (departmentCreated)
            {
                _logger.LogInformation("Started creating a Department with Id: {DepartmentId}", department.Id);
                return Result<bool>.Success();
            }
            _logger.LogWarning("Failed to create a Department with Id: {DepartmentId}", department.Id);
            return Result<bool>.Failure(DepartmentError.CreationFailed);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the {ServiceName} while attempting to create a Department with Id: {DepartmentId}",
                             nameof(DepartmentService), department.Id);
            return Result<bool>.Failure(DepartmentError.CreationUnexpectedError);
        }
    }

    public async Task<Result<List<Department>>> GetAllDepartmentsAsync(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Started retrieving all departments.");

            var departments = await _departmentRepository.GetAllAsync(cancellationToken);

            if (departments is null)
            {
                return Result<List<Department>>.Failure(DepartmentError.RetrievalError);
            }

            _logger.LogInformation("Successfully retrieved all departments.");

            return Result<List<Department>>.Success(departments.ToList());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the {ServiceName} while attempting to retrieve all departments.", nameof(DepartmentService));
            return Result<List<Department>>.Failure(DepartmentError.RetrievalError);
        }
    }

    public async Task<Result<Department>> GetDepartmentByIdAsync(int departmentId, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Started retrieving Department with Id: {DepartmentId}", departmentId);

            var department = await _departmentRepository.GetByIdAsync(departmentId, cancellationToken);

            if (department is null)
            {
                _logger.LogWarning("Breed with Id: {BreedId} was not found.", departmentId);
                return Result<Department>.Failure(DepartmentError.NotFound(departmentId));
            }

            _logger.LogInformation("Successfully retrieved Department with Id: {BreedId}", departmentId);
            return Result<Department>.Success(department);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the {ServiceName} while attempting to retrieve Department with Id: {BreedId}",
                             nameof(DepartmentService), departmentId);
            return Result<Department>.Failure(DepartmentError.RetrievalError);
        }
    }

    public async Task<Result<bool>> UpdateDepartmentAsync(Department department, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Started updating Department with Id: {DepartmentId}", department.Id);

            await _departmentRepository.UpdateAsync(department, cancellationToken);
            var departmentUpdated = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

            if (departmentUpdated)
            {
                _logger.LogInformation("Successfully updated Department with Id: {DepartmentId}", department.Id);
                return Result<bool>.Success();
            }
            _logger.LogWarning("Failed to update Department with Id: {DepartmentId}. No changes were detected.", department.Id);
            return Result<bool>.Failure(DepartmentError.NoChangesDetected);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the {ServiceName} while attempting to update Department with Id: {DepartmentId}",
                             nameof(DepartmentService), department.Id);
            return Result<bool>.Failure(DepartmentError.UpdateUnexpectedError);
        }
    }

    public async Task<Result<bool>> DeleteDepartmentAsync(int departmentId, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Started deleting Department with Id: {DepartmentId}", departmentId);

            var department = await _departmentRepository.GetByIdAsync(departmentId, cancellationToken);
            if (department is null)
            {
                _logger.LogWarning("Department with Id: {DepartmentId} was not found.", departmentId);
                return Result<bool>.Failure(DepartmentError.NotFound(departmentId));
            }

            await _departmentRepository.DeleteAsync(department, cancellationToken);
            var breedDeleted = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

            if (breedDeleted)
            {
                _logger.LogInformation("Successfully deleted Department with Id: {BreedId}", departmentId);
                return Result<bool>.Success();
            }
            _logger.LogWarning("Failed to delete Department with Id: {DepartmentId}. No changes were detected.", departmentId);
            return Result<bool>.Failure(DepartmentError.NoChangesDetected);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in the {ServiceName} while attempting to delete Department with Id: {DepartmentId}",
                             nameof(DepartmentService), departmentId);
            return Result<bool>.Failure(DepartmentError.DeletionUnexpectedError);
        }
    }
}
