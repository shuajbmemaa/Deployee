using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Domain.Interfaces;

public interface ISoftDeletion
{
    public bool IsDeleted { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }

    public void Undo()
    {
        IsDeleted = false;
        DeletedAt = null;
    }
}