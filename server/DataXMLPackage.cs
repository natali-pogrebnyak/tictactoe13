using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    [Serializable]

    class DataXMLPackage
    {
        private string id_user; // идентификатор пользователя
        private string recipient; // IP получатель
        private string sender; // IP отправитель
        private string type; // тип данных
        private string data; // тип данных
        private string date_s; // отправки
        private string date_r; // дата приема
        private string desc; // описание данных
    }
}
