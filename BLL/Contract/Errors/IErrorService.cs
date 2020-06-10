using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Contract.Errors
{
    public interface IErrorService
    {
        Exception CreateException(Exception ex, int moduleCode, int methodCode);
    }
}
