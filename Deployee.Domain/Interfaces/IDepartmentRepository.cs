using Deployee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Domain.Interfaces;

public interface IDepartmentRepository : IGenericRepository<Department, int> { }
