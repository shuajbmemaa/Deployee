using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deployee.Domain.Enums;

namespace Deployee.Domain.Entities;

public class Tasks
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Title { get; set; }

    public string Description { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    [MaxLength(50)]
    public Status Status { get; set; }

    [Required]
    [MaxLength(50)]
    public Priority Priority { get; set; }

    public string FunFact { get; set; }

    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}