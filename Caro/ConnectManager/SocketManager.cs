using Caro.Setting;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Caro.ConnectManager
{
    class SocketManager
    {
        #region both
        private static string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            output = ip.Address.ToString();
                    }
                }
            }
            return output;
        }

        public static string GetIPv4()
        {
            string result = SocketManager.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(result))
                result = SocketManager.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            return result;
        }
        #endregion

        #region CLIENT
        Socket client;
        public bool ConnectServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(CONST.IP), CONST.PORT);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(iep);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region SERVER
        public void CreateServer()
        {
            Socket server;
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(CONST.IP), CONST.PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(iep);
            server.Listen(10);
            client = server.Accept();
        }
        #endregion
    }
}
