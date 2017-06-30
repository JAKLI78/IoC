using System;
using Castle.Core.Logging;
using SomeLogicLibrary.Interface;

namespace SomeLogicLibrary.Notificators
{
    public class SmsNotificator : INotificator
    {
        private readonly ILogger _logger;

        public SmsNotificator(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger), $"{nameof(logger)} cannot be null.");
        }

        public void Send(string message)
        {
            _logger.Info(message);
        }
    }
}