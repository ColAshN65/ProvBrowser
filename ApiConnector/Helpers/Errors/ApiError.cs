namespace ApiConnector.Helpers.Errors;

public partial class ApiError
{
    public static readonly ApiError None = new(string.Empty, string.Empty);
    public static readonly ApiError NullValue = new("Error.NullValue", "The specified result value is null.");

    public ApiError(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public string Code { get; }

    public string Message { get; }

    public static implicit operator string(ApiError error) => error.Code;

    public static bool operator ==(ApiError? a, ApiError? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    public static bool operator !=(ApiError? a, ApiError? b) => !(a == b);

    public virtual bool Equals(ApiError? other)
    {
        if (other is null)
        {
            return false;
        }

        return Code == other.Code && Message == other.Message;
    }

    public override bool Equals(object? obj) => obj is ApiError error && Equals(error);

    public override int GetHashCode() => HashCode.Combine(Code, Message);

    public override string ToString() => Code;
}
