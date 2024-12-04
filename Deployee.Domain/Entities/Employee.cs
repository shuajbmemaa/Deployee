using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Domain.Entities;

public class Employee
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    public string Surname { get; set; }

    [Required]
    [EmailAddress]
    [MaxLength(200)]
    public string Email { get; set; }

    [Phone]
    [MaxLength(15)]
    public string PhoneNumber { get; set; }

    [Required]
    public DateTime DateOfJoining { get; set; }

    [ForeignKey("Department")]
    public int DepartmentId { get; set; }
    public Department Department { get; set; }

    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}

