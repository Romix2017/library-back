using BLL.Contract.Errors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete.Errors
{
    public class ErrorService : IErrorService
    {
        internal readonly ILogger<ErrorService> _log;
        public ErrorService(ILogger<ErrorService> log)
        {
            _log = log;
        }
        public Exception CreateException(Exception ex, int moduleCode, int methodCode)
        {
            int codeError = moduleCode + methodCode;
            _log.LogError(ex, "ERROR CODE: {codeError}", codeError);
            string codeMessage = $"Please contact technical support, code error: { codeError}";
            return new Exception(codeMessage);
        }
    }
}
