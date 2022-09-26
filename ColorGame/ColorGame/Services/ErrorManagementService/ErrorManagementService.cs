using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ColorGame.Services
{
    public class ErrorManagementService : IErrorManagementService
    {
        public void HandleError(Exception ex)
        {
#if RELEASE
            Report(ex);
#elif DEBUG
            Debug.WriteLine(ex);
#endif
        }

        private void Report(Exception ex)
        {
            //TODO: Crash Report 
        }
    }
}
