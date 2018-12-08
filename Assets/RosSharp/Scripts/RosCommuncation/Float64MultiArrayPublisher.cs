using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RosSharp.RosBridgeClient
{
    public class Float64MultiArrayPublisher : Publisher<Messages.Standard.Float64MultiArray>
    {
        public float[] messageData;

        private Messages.Standard.Float64MultiArray message;

        protected override void Start()
        {
            base.Start();
            InitializeMessage();
        }

        private void InitializeMessage()
        {
            message = new Messages.Standard.Float64MultiArray
            {
                data = messageData
            };
        }

        private void Update()
        {
        }

        public void PublishPosition(float[] msg)
        {

            messageData = msg;
            message.data = messageData;
            Publish(message);
        }
    }
}