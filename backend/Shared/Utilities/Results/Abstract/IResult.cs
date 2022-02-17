using Shared.Utilities.Results.ComplexTypes;

namespace Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultCode ResultCode { get;}
        public string Message { get; }
        public Exception Exception { get; }
    }
}
