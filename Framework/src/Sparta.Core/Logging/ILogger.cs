using System;

namespace Sparta.Core.Logging
{
    public interface ILogger
    {
        void Error(Exception ex);
        void Info(string template, string[] parameters);
        void Warn(string template, string[] parameters);
        //...
    }
}
