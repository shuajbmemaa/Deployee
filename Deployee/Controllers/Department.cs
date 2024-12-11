using AutoMapper;
using Deployee.Application.Interfaces;
using Deployee.Domain.Entities;
using Deployee.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace Deployee.Controllers;

public class DepartmentController : Controller
{
    private readonly IDepartmentService _departmentService;
    private readonly IMapper _mapper;
    public DepartmentController(IDepartmentService departmentService,IMapper mapper)
    {
        _departmentService = departmentService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var result = await _departmentService.GetAllDepartmentsAsync(cancellationToken);

        if (result.IsSuccess)
        {
            var departments = _mapper.Map<List<DepartmentViewModel>>(result.Value);
            return View(departments);
        }

        return View(new List<DepartmentViewModel>());
    }

    public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
    {
        var departments = await _departmentService.GetDepartmentByIdAsync(id, cancellationToken);
        return View(departments);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Department department, CancellationToken cancellationToken)
    {
        await _departmentService.CreateDepartmentAsync(department, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id, cancellationToken);
        return View(department);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Department department, CancellationToken cancellationToken)
    {
        await _departmentService.UpdateDepartmentAsync(department, cancellationToken);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id, cancellationToken);
        return View(department);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
    {
        await _departmentService.DeleteDepartmentAsync(id, cancellationToken);
        return RedirectToAction(nameof(Index));
    }
}