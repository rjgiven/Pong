namespace Pong.Services
{
    public interface ICommService
    {
        void SendCommand(string cmd);
        void Start();
        void Stop();
    }
}