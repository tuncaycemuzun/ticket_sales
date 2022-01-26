﻿using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(ResultCode resultStatus, T data)
        {
            ResultStatus = resultStatus;
            Data = data;
        }
        public DataResult(ResultCode resultStatus, string message, T data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Data = data;
        }
        public DataResult(ResultCode resultStatus, string message, Exception e, T data)
        {
            ResultStatus = resultStatus;
            Message = message;
            Exception = e;
            Data = data;
        }

        public ResultCode ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
        public T Data { get; }
    }
}
