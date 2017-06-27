using Castle.Core.Logging;
using SomeLogicLibrary.Interface;

namespace SomeLogicLibrary.Class
{
    public class SmsNotificator:INotificator
    {
        private readonly ILogger _logger;

        public SmsNotificator(ILogger logger)
        {
            _logger = logger;
        }
        public void Send(string message)
        {
            _logger.Info(message);
        }
    }
}
