## RBX1 Unity Control
RBX1 arm remote viewer. Connects to a running ROS device, and receives and delivers messages over ROS topics. 
* Viewer displays current physical state of the arm
* User can move and position a virtual arm and then commit action to physical arm


|![IP input screen](../assets/start.png?raw=true)   |![Remote viewer and controller](../assets/viewer.png?raw=true)   | 
|---|---|
| Start screen | Rbx1 remote viewer |


## User Guide
Set up [rbx1_ros](https://github.com/Statoil/rbx1_ros) on a RPi that is connected to the RBX1 robot or a simulator. Build or get a release of the [rbx1_unity](https://github.com/Statoil/rbx1_unity) remote viewer and controller. Get the ip (`ifconfig`) of the RPi, and make sure both the computer and RPi are running on the same network. Start the RBX1 viewer and enter ip address. Hit `start`.

* Hold shift and scroll/ drag mouse to change camera orientation and distance.
* Use a controller or use keyboard to change angle of joints. 
  * Arrow keys, home, end, page up, page down, including key 1 to 4 will trigger movement of virtual robot.
* Send pose to RPi by clicking `Apply`.
* `Home` resets robot to initial pose.


## Notes
The `RosBridgeClient.dll` (Assets -> RosSharp -> Plugins) has been extended with new message types, as described [here](https://github.com/siemens/ros-sharp/wiki/Dev_NewMessageTypes). The following has been added:

```csharp
namespace RosSharp.RosBridgeClient.Messages.Standard
{
    public class Float64MultiArray : Message
    {
        [JsonIgnore]
        public const string RosMessageName = "std_msgs/Float64MultiArray";
        public float[] data;

        public Float64MultiArray()
        {
            data = new float[0];
        }
    }
}
```
Clone [ros-sharp source](https://github.com/siemens/ros-sharp), and follow the guide above to further extend `RosBridgeClient.dll`. Note, that you need to checkout the version 1.3 commit, before you start. Replace the dll file in this repository when done.
