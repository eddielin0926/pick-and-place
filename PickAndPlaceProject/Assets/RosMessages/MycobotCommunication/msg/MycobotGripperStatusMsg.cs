//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.MycobotCommunication
{
    [Serializable]
    public class MycobotGripperStatusMsg : Message
    {
        public const string k_RosMessageName = "mycobot_communication/MycobotGripperStatus";
        public override string RosMessageName => k_RosMessageName;

        public bool Status;

        public MycobotGripperStatusMsg()
        {
            this.Status = false;
        }

        public MycobotGripperStatusMsg(bool Status)
        {
            this.Status = Status;
        }

        public static MycobotGripperStatusMsg Deserialize(MessageDeserializer deserializer) => new MycobotGripperStatusMsg(deserializer);

        private MycobotGripperStatusMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.Status);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.Status);
        }

        public override string ToString()
        {
            return "MycobotGripperStatusMsg: " +
            "\nStatus: " + Status.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}