using System.Diagnostics.CodeAnalysis;
using MediatR;

namespace BakerySystem.Domain.Common;
public class Result<T> 
{
    
    public T? Value { get; }
    [MemberNotNullWhen(true, nameof(Value))]
    public bool IsSuccess { get; }

    [MemberNotNullWhen(false, nameof(Value))]
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    protected Result(bool isSuccess, T? value, Error error)
    {
        switch (isSuccess)
        {
            case true when error != Error.None:
                throw new InvalidOperationException("A successful result cannot have an error.");
            case false when error == Error.None:
                throw new InvalidOperationException("A failed result must have an error.");
        }

        IsSuccess = isSuccess;
        Value = value;
        Error = error;
    }



    public static Result<T> Success(T value) => new(true, value, Error.None);
    public static Result<T> Failure(Error error) => new(false, default, error);

    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Failure(error);

}

