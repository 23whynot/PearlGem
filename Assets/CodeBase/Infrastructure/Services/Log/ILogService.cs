using UnityEngine;

namespace CodeBase.Services.Log
{
    public interface ILogService
    {
        public void Log(string msg);

        public void LogError(string msg);

        public void LogWarning(string msg);
    }
}