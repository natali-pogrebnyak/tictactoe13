using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class Identity
    {
        /// <summary>
        /// идентификатор пользователя
        /// </summary>
        private string s_id
        {
            get;
            set;
        }

        /// <summary>
        /// ip пользователя
        /// </summary>
        public string s_ip
        {
            get;
            set;
        }

        /// <summary>
        /// имя пользователя
        /// </summary>
        public string s_name
        {
            get;
            set;
        }

        /// <summary>
        /// статус пользователя
        /// </summary>
        public string s_status
        {
            get;
            set;
        }

        /// <summary>
        /// время входа пользователя
        /// </summary>
        public DateTime d_login
        {
            get;
            set;
        }

        public Identity()
        {

        }

        public Identity(string ip, string name, string status)
        {
            s_ip = ip;
            s_name = name;
            s_status = status;
            d_login = DateTime.Now;
        }

        public static Identity getIdentityUser(string id)
        {
            /*код с запросом данных о пользователе по ID будет позже*/
            return new Identity();
        }
    }
}
