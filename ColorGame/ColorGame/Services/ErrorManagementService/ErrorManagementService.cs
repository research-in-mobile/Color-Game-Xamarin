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
            LocalLog(ex);
#if RELEASE
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                SendReport(ex);
            }
#elif DEBUG
            Debug.WriteLine(ex);
#endif
        }

        private void SendReport(Exception ex)
        {
            //TODO: HTTPS Crash Report
        }

        private void LocalLog(Exception ex)
        {
            var logFileName = CreateLogFile();
            Debug.WriteLine("Log file created: " + logFileName);
        }

        private string CreateLogFile()
        {
            //TODO:

            return string.Empty;
        }
    }
}
