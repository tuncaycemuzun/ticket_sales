using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;

namespace Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultCode resultCode)
        {
            ResultCode = resultCode;
        }
        public Result(ResultCode resultCode, string message)
        {
            ResultCode = resultCode;
            Message = message;
        }
        public Result(ResultCode resultCode, string message, Exception e)
        {
            Exception = e;
            ResultCode = resultCode;
            Message = message;
        }
        public ResultCode ResultCode { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
