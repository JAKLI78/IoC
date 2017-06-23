using System.Net.Mail;

namespace SomeLogicLibrary.Interface
{
    public interface INotificator
    {
        void Send(string message);
    }
}