using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Server
{
    [Serializable]
    class DataXMLPackage
    {
        /// <summary>
        /// идентификатор пользователя
        /// </summary>
        public string s_id_user
        {
            get;
            set;
        }

        /// <summary>
        /// IP получатель
        /// </summary>
        public string s_ip_recipient
        {
            get;
            set;
        }

        /// <summary>
        /// IP отправитель
        /// </summary>
        public string s_ip_sender
        {
            get;
            set;
        }

        /// <summary>
        /// тип данных
        /// </summary>
        public string s_type
        {
            get;
            set;
        }

        /// <summary>
        /// данные
        /// </summary>
        public string s_data
        {
            get;
            set;
        }

        /// <summary>
        /// дата отправки
        /// </summary>
        public string d_date_s
        {
            get;
            set;
        }

        /// <summary>
        /// дата приема
        /// </summary>
        [XmlIgnore]
        public string d_date_r
        {
            get;
            set;
        }

        /// <summary>
        /// описание данных
        /// </summary>
        public string s_desc
        {
            get;
            set;
        }

    }
}
