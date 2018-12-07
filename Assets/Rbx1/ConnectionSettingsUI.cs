using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RBX1.UI
{
  public class ConnectionSettingsUI : MonoBehaviour {

  private string ipAddrString = "127.0.0.1";
  public delegate void ClickAction(string ip);
  public delegate void StartAction();
  public static event ClickAction OnConnectClicked;
  public static event StartAction OnStartClicked;

    void OnGUI ()
      {
          // Make a background box
          GUI.Box(new Rect(10,10,110,120), "ROS");
          ipAddrString = GUI.TextField (new Rect (20, 35, 90, 25), ipAddrString);

          if(GUI.Button(new Rect(20,70,80,20), "Connect") && OnConnectClicked != null)
          {
            OnConnectClicked(ipAddrString);
          }

          if(GUI.Button(new Rect(20,90,80,20), "Start") && OnStartClicked != null)
          {
            OnStartClicked();   
          }
      }
  }
}
