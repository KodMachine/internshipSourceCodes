using System;
using System.Net;
using System.Net.Sockets;
using ServerApp.Models;

namespace ServerApp
{
    public class Methods
    {
        [Obsolete]
        public static string GetIp()
        { 
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                return endPoint.Address.ToString();
            }
        }

        [Obsolete]
        public static Log newLog(string detail, string explanation, bool proccesSuccess)
        {
            return new Log 
                {
                    ProccesSuccess = proccesSuccess,
                    Detail = detail,
                    Ip = Methods.GetIp(),
                    DateHour = DateTime.Now,
                    Explanation = explanation
                };
        }
    }
}