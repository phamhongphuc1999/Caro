﻿// Copyright (c) Microsoft. All Rights Reserved.
//  License under the Apache License, Version 2.0.
//  Owner: Pham Hong Phuc

using CaroGame.Configuration;
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

        /// <summary>
        /// Return the IP of network
        /// </summary>
        /// <param name="_type">The specified network interface type</param>
        /// <returns>The string represent of IP</returns>
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

        /// <summary>
        /// Return the IP of network
        /// </summary>
        /// <returns>The string represent of IP</returns>
        public static string GetIPv4()
        {
            string result = LANManager.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(result))
                result = LANManager.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            return result;
        }

        /// <summary>
        /// Check form of IP
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Send message by socket
        /// </summary>
        /// <param name="message">data to send</param>
        /// <param name="flags">Specified socket send and receive behavior</param>
        /// <returns></returns>
        public int SEND_TCP(MessageData message, SocketFlags flags)
        {
            byte[] bData = Data.SerializeData(message);
            return client.Send(bData, bData.Length, flags);
        }

        /// <summary>
        /// receive message by socket
        /// </summary>
        /// <param name="message">the receive message</param>
        /// <param name="flags"></param>
        /// <returns></returns>
        public int RECEIVE_TCP(ref MessageData message, SocketFlags flags)
        {
            byte[] bData = new byte[Config.BUFF_SIZE];
            int result = client.Receive(bData, Config.BUFF_SIZE, flags);
            message = (MessageData)Data.DeserializeData(bData);
            return result;
        }
        #endregion

        #region CLIENT
        /// <summary>
        /// Initilized client and connect to server
        /// </summary>
        /// <returns></returns>
        public bool ConnectServer()
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(Config.IP), Config.PORT);
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
        /// <summary>
        /// Create server
        /// </summary>
        /// <returns></returns>
        public bool CreateServer()
        {
            try
            {
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(Config.IP), Config.PORT);
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
