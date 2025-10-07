using ClientApp.Model;
using ClientApp.View;
using ClientApp.Controller;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 8888;
            ChatModel model = new ChatModel(ip, port);
            ChatView view = new ChatView();
            ChatController controller = new ChatController(model, view);
            controller.Start();
        }
    }
}
