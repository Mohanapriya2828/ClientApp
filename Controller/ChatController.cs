using ClientApp.Model;
using ClientApp.View;
using System;

namespace ClientApp.Controller
{
    public class ChatController
    {
        private readonly ChatModel _model;
        private readonly ChatView _view;

        public ChatController(ChatModel model, ChatView view)
        {
            _model = model;
            _view = view;
        }
        public void Start()
        {
            try
            {
                _model.Connect();
                _view.ShowMessage("[CLIENT] Connected to server.");

                while (true)
                {
                    string msg = _view.GetInput("[CLIENT]: ");
                    _model.SendMessage(msg);

                    if (msg.Equals("exit", StringComparison.OrdinalIgnoreCase))
                        break;

                    string reply = _model.ReceiveMessage();
                    _view.ShowMessage($"[SERVER]: {reply}");

                    if (reply.Equals("exit", StringComparison.OrdinalIgnoreCase))
                        break;
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"[CLIENT ERROR] {ex.Message}");
            }
            finally
            {
                _model.Close();
            }
        }
    }
}
