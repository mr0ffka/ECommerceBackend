using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Contracts.Logging
{
    public interface IAppLogger<T>
    {
        void LogInfo(string message, params object[] args);
        void LogWarn(string message, params object[] args);
        void LogErr(string message, params object[] args);
    }
}
