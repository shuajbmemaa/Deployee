using Deployee.Domain.Entities;
using Deployee.Domain.Interfaces;
using Deployee.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Infrastructure.Repositories;

public class DepartmentRepository : GenericRepository<Department, int>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext context) : base(context)
    {
    }
}
