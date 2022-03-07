using System;
using System.Net;
using System.Net.Sockets;
using ServerApp.Models;
using System.Text;  
using System.Security.Cryptography; 

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
        
        public static string Sha256(string rawData)  
        {  
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  
                StringBuilder builder = new StringBuilder();  

                for (int i = 0; i < bytes.Length; i++)  
                {  
                    builder.Append(bytes[i].ToString("x2"));  
                }  

                return builder.ToString();  
            }  

        } 
    }
}