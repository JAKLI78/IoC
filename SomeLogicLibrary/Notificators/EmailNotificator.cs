using System;
using Castle.Core.Logging;
using SomeLogicLibrary.Interface;

namespace SomeLogicLibrary.Class
{
    public class EmailNotificator : INotificator
    {
        private readonly ILogger _logger;

        public EmailNotificator(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException("logger");
        }

        public void Send(string message)
        {
            _logger.Info(message);
        }
    }
}