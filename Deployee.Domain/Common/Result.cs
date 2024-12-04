using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Deployee.Domain.Common;

public class Result<T>
{
    private readonly List<Error> _errors = new();

    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool IsSuccess { get; }

    /// <summary>
    /// Gets the value produced by the operation, if it was successful.
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// Gets the list of errors associated with the operation, if it was not successful.
    /// </summary>
    public IReadOnlyList<Error> Errors => _errors.AsReadOnly();

    private Result(bool isSuccess, T? value, IReadOnlyList<Error> errors)
    {
        IsSuccess = isSuccess;
        Value = value;

        if (errors.Any())
        {
            _errors.AddRange(errors);
        }
    }

    /// <summary>
    /// Creates a successful result with the specified value.
    /// </summary>
    /// <param name="value">The value to return in the result.</param>
    /// <returns>A successful <see cref="Result{T}"/> instance.</returns>
    public static Result<T> Success(T? value = default)
    {
        return new Result<T>(isSuccess: true, value: value, errors: new List<Error>());
    }

    /// <summary>
    /// Creates a failed result with a general error message.
    /// </summary>
    /// <param name="error">The error message to include in the result.</param>
    /// <returns>A failed <see cref="Result{T}"/> instance with the specified error message.</returns>
    public static Result<T> Failure(string error)
    {
        return new Result<T>(isSuccess: false, value: default, errors: new List<Error> { new Error("General.Error", error) });
    }

    /// <summary>
    /// Creates a failed result with one or more specific errors.
    /// </summary>
    /// <param name="errors">The errors to include in the result.</param>
    /// <returns>A failed <see cref="Result{T}"/> instance with the specified errors.</returns>
    public static Result<T> Failure(params Error[] errors)
    {
        return new Result<T>(isSuccess: false, value: default, errors: errors);
    }
}

