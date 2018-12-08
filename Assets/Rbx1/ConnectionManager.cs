using System.Collections;
using System.Collections.Generic;
using RosSharp.RosBridgeClient;
using UnityEngine;
using System.Net;
using RosSharp.RosBridgeClient.Protocols;
using RBX1.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Net.Sockets;

namespace RBX1.Manager
{

    public class ConnectionManager : MonoBehaviour
    {

        public bool isValidIp;
        public GameObject ValidElement;
        // Use this for initialization
        void Start()
        {
            ValidElement.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TestIp(string ip)
        {
            if (!CheckValidIP(ip))
            {
                isValidIp = false;
                ValidElement.SetActive(false);
            }
            else
            {
                RosConnector.ServerUrl = $"ws://{ip}:9090";
                isValidIp = true;
                ValidElement.SetActive(true);
            }
        }

        public void StartRbx1()
        {
            if (!isValidIp) return;
            SceneManager.LoadScene("Rbx1Scene", LoadSceneMode.Single);
        }

        private static bool CheckValidIP(string ip)
        {
            if (ip == null || "".Equals(ip)) return false;
            if (ip.Count(c => c == '.') != 3 && !ip.Contains(":")) return false;
            IPAddress result = null;
            return IPAddress.TryParse(ip, out result);
        }
    }
}
