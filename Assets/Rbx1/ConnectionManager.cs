using System.Collections;
using System.Collections.Generic;
using RosSharp.RosBridgeClient;
using UnityEngine;
using System.Net;
using RosSharp.RosBridgeClient.Protocols;
using RBX1.UI;
using UnityEngine.SceneManagement;

namespace RBX1.Manager
{
    public class ConnectionManager : MonoBehaviour {
      
      public GameObject RosConnectorObject;
      // Use this for initialization
      void Start () {
        ConnectionSettingsUI.OnConnectClicked += ConnectToIp;
        ConnectionSettingsUI.OnStartClicked += StartRbx1;        
      }
      
      // Update is called once per frame
      void Update () {
        
      }

      public void ConnectToIp(string ip) {
        if (!CheckValidIP(ip)) return;
        RosConnector.ServerUrl = $"ws://{ip}:9090";
      }

      public void StartRbx1() {
        SceneManager.LoadScene("Rbx1Scene", LoadSceneMode.Single);
      }

      public static bool CheckValidIP(string ip)
      {
          IPAddress result = null;
          return
              ip != null && !"".Equals(ip) &&
              IPAddress.TryParse(ip, out result);
      }
    }
}
