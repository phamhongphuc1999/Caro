using CaroGame.Config;
using DataTransmission;
using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;

namespace CaroGame.LANManagement
{
    class LANManager
    {
        #region both
        public Socket client, server;

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
            string result = LANManager.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(result))
                result = LANManager.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            return result;
        }

        public static bool CheckIP(string IP)
        {
            string[] IdArr = IP.Split('.');
            if (IdArr.Length != 4) return false;
            else
            {
                int temp = 0; bool check;
                foreach (string item in IdArr)
                {
                    check = Int32.TryParse(item, out temp);
                    if (!check || temp > 255) return false;
                }
                return true;
            }
        }

        public int SEND_TCP(MessageData message, SocketFlags flags)
        {
            byte[] bData = Data.SerializeData(message);
            return client.Send(bData, bData.Length, flags);
        }

        public int RECEIVE_TCP(ref MessageData message, SocketFlags flags)
        {
            byte[] bData = new byte[CONST.BUFF_SIZE];
            int result = client.Receive(bData, CONST.BUFF_SIZE, flags);
            message = (MessageData)Data.DeserializeData(bData);
            return result;
        }
        #endregion

        #region CLIENT
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
        public bool CreateServer()
        {
            try
            {
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(CONST.IP), CONST.PORT);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                server.Bind(iep);
                server.Listen(10);
                Thread acceptThread = new Thread(() =>
                {
                    client = server.Accept();
                });
                acceptThread.IsBackground = true;
                acceptThread.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
