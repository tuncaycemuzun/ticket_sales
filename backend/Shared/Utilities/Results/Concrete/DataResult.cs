using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;

namespace Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultCode resultCode, T data)
        {
            ResultCode = resultCode;
            Data = data;
        }
        public DataResult(ResultCode resultCode, string message)
        {
            ResultCode = resultCode;
            Message = message;
        }
        public DataResult(ResultCode resultCode, string message, T data)
        {
            ResultCode = resultCode;
            Message = message;
            Data = data;
        }
        public DataResult(ResultCode resultCode, string message, Exception e, T data)
        {
            ResultCode = resultCode;
            Message = message;
            Exception = e;
            Data = data;
        }

        public ResultCode ResultCode { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public T Data { get; }
    }
}
