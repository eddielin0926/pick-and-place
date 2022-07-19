//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.MycobotCommunication
{
    [Serializable]
    public class GetAnglesResponse : Message
    {
        public const string k_RosMessageName = "mycobot_communication/GetAngles";
        public override string RosMessageName => k_RosMessageName;

        public float joint_1;
        public float joint_2;
        public float joint_3;
        public float joint_4;
        public float joint_5;
        public float joint_6;

        public GetAnglesResponse()
        {
            this.joint_1 = 0.0f;
            this.joint_2 = 0.0f;
            this.joint_3 = 0.0f;
            this.joint_4 = 0.0f;
            this.joint_5 = 0.0f;
            this.joint_6 = 0.0f;
        }

        public GetAnglesResponse(float joint_1, float joint_2, float joint_3, float joint_4, float joint_5, float joint_6)
        {
            this.joint_1 = joint_1;
            this.joint_2 = joint_2;
            this.joint_3 = joint_3;
            this.joint_4 = joint_4;
            this.joint_5 = joint_5;
            this.joint_6 = joint_6;
        }

        public static GetAnglesResponse Deserialize(MessageDeserializer deserializer) => new GetAnglesResponse(deserializer);

        private GetAnglesResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.joint_1);
            deserializer.Read(out this.joint_2);
            deserializer.Read(out this.joint_3);
            deserializer.Read(out this.joint_4);
            deserializer.Read(out this.joint_5);
            deserializer.Read(out this.joint_6);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.joint_1);
            serializer.Write(this.joint_2);
            serializer.Write(this.joint_3);
            serializer.Write(this.joint_4);
            serializer.Write(this.joint_5);
            serializer.Write(this.joint_6);
        }

        public override string ToString()
        {
            return "GetAnglesResponse: " +
            "\njoint_1: " + joint_1.ToString() +
            "\njoint_2: " + joint_2.ToString() +
            "\njoint_3: " + joint_3.ToString() +
            "\njoint_4: " + joint_4.ToString() +
            "\njoint_5: " + joint_5.ToString() +
            "\njoint_6: " + joint_6.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Response);
        }
    }
}