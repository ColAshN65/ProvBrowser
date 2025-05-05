using ApiConnector.Helpers.Errors;

namespace ApiConnector.Helpers;

public class ApiResult
{
    protected internal ApiResult(bool isSuccess, ApiError error)
    {
        if (isSuccess && error != ApiError.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == ApiError.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public ApiError Error { get; }

    public static ApiResult Success() => new(true, ApiError.None);

    public static ApiResult<TValue> Success<TValue>(TValue value) => new(value, true, ApiError.None);

    public static ApiResult Failure(ApiError error) => new(false, error);

    public static ApiResult<TValue> Failure<TValue>(ApiError error) => new(default, false, error);

    public static ApiResult<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(ApiError.NullValue);

    internal static ApiResult<T> Failure<T>(object invalidId)
    {
        throw new NotImplementedException();
    }
}

public class ApiResult<TValue> : ApiResult
{
    private readonly TValue? _value;

    protected internal ApiResult(TValue? value, bool isSuccess, ApiError error)
        : base(isSuccess, error) =>
        _value = value;

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result can not be accessed.");

    public static implicit operator ApiResult<TValue>(TValue? value) => Create(value);
}
