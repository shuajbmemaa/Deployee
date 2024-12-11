using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Domain.Common;

public static class DepartmentError
{

    public static Error NotFound(int id) => new Error("Department.NotFound", $"Department with ID {id} was not found.");

    public static Error NoChangesDetected => new Error("Department.NoChanges", "No changes were detected during the operation.");

    public static Error CreationFailed => new Error("Department.CreationFailed", "Department creation failed. No changes were made to the database.");

    public static Error CreationUnexpectedError => new Error("Department.CreationUnexpectedError", "An unexpected error occurred during department creation.");

    public static Error RetrievalError => new Error("Department.RetrievalError", "An error occurred while retrieving the list of departments.");

    public static Error UpdateUnexpectedError => new Error("Department.UpdateUnexpectedError", "An unexpected error occurred during the update operation.");

    public static Error DeletionUnexpectedError => new Error("Department.DeletionUnexpectedError", "An unexpected error occurred during the deletion operation.");
}