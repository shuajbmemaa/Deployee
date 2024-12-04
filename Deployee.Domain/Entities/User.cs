using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool IsDeleted { get; set; }

    public DateTimeOffset? DeletedAt { get; set; }
}
