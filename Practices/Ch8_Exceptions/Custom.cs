using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ch8_Exceptions
{
    class Custom
    {
        public class DeviceNotReadyException: InvalidCastException
        {
            public DeviceNotReadyException(DeviceStatus status)
                :this("Device must in Ready status", status)
            {

            }
            public DeviceNotReadyException(string message, DeviceStatus status)
                :base(message)
            {
                Status = status;
            }
            public DeviceNotReadyException(string message, DeviceStatus status, Exception innerException)
                :base(message, innerException)
            {
                Status = status;
            }

            /// <summary>
            /// 使得该Exception变得可serialization
            /// </summary>
            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                base.GetObjectData(info, context);
                info.AddValue("status", Status);
            }

            public DeviceNotReadyException(SerializationInfo info, StreamingContext context)
                :base(info, context)
            {
                Status = (DeviceStatus)info.GetValue("status", typeof(DeviceStatus));
            }

            public DeviceStatus Status { get; private set; }
        }

        public enum DeviceStatus
        {
            Disconnected,
            Initializint,
            Failed,
            Ready
        }
    }
}
