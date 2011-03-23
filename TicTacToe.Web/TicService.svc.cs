using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TicTacToe.Web
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    [ServiceContract(Namespace = "", CallbackContract = typeof(ITicService))]
    public class TicService
    {
        [ServiceContract]
        public interface ITicService
        {
            [OperationContract(IsOneWay = true, AsyncPattern = true)]
            IAsyncResult BeginUserConnected(string UserName, AsyncCallback callback, object state);

            void EndUserConnected(IAsyncResult result);

            [OperationContract(IsOneWay = true, AsyncPattern = true)]
            IAsyncResult BeginUserDisconnected(string UserName, AsyncCallback callback, object state);

            void EndUserDisconnected(IAsyncResult result);

            [OperationContract(IsOneWay = true, AsyncPattern = true)]
            IAsyncResult BeginSendMessage(string Message, AsyncCallback callback, object state);

            void EndSendMessage(IAsyncResult result);
        }
    }
}
