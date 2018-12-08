## RBX1 Unity Control
RBX1 arm remote viewer. Connects to a running ROS device, and receives and delivers messages over ROS topics. 
* Viewer displays current physical state of the arm
* User can move and position a virtual arm and then commit action to physical arm


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
