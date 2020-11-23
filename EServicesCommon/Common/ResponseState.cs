namespace EServicesCommon.Common
{
    public enum ResponseState
    {
        Success = 100,
        Failure = 101,
        ValidationError = 102,
        AccessDenied = 103,
        InvalidParameter = 104,
        ResourceNotExists = 105
    }
}
