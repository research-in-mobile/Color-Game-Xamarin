using System;
using System.Collections.Generic;
using System.Text;

namespace ColorGame.Services
{
    public interface IErrorManagementService
    {
        void HandleError(Exception ex);
    }
}
