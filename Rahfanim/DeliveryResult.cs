using System;

namespace Rahfanim;

public class DeliveryResult
{
    public bool IsSuccess { get; }
    public string Message { get; }

    private DeliveryResult(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static DeliveryResult Success(string message = "Operation completed successfully.")
    {
        return new DeliveryResult(true, message);
    }
    public static DeliveryResult Failure(string errorMessage = "Operation completed unsuccessfully")
    {
        return new DeliveryResult(false, errorMessage);
    }
}
