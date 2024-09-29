namespace CleanArchDemo.Core.Shared;

public class ResultT<TValue>(TValue value, bool isSuccess, Error error)
    : Result(isSuccess, error)
{
    public TValue Value => IsSuccess
        ? value
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static ResultT<TValue> Success(TValue value) => new(value, true, Error.None);

    public static new ResultT<TValue> Failure(Error error) => new(default!, false, error);

    public static ResultT<TValue> Create(TValue? value) => value is not null
        ? Success(value)
        : Failure(Error.NullValue);

    public static implicit operator ResultT<TValue>(TValue? value) => Create(value);
}
