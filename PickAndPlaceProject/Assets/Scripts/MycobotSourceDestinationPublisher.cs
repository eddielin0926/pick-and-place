using System;
using System.Collections;
using RosMessageTypes.Geometry;
using RosMessageTypes.MycobotCommunication;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using Unity.Robotics.UrdfImporter;
using UnityEngine;

public class MycobotSourceDestinationPublisher : MonoBehaviour
{
    const int k_NumRobotJoints = 6;

    public static readonly string[] LinkNames =
        { "joint1/joint2", "/joint3", "/joint4", "/joint5", "/joint6", "/joint6_flange" };

    // Variables required for ROS communication
    [SerializeField]
    string m_TopicName = "mycobot/angles_goal";

    [SerializeField]
    GameObject m_Mycobot;
    readonly Quaternion m_PickOrientation = Quaternion.Euler(90, 90, 0);

    // Robot Joints
    ArticulationBody[] m_JointArticulationBodies;

    // ROS Connector
    ROSConnection m_Ros;

    void Start()
    {
        // Get ROS connection static instance
        m_Ros = ROSConnection.GetOrCreateInstance();
        m_Ros.RegisterPublisher<MycobotSetAnglesMsg>(m_TopicName);

        m_JointArticulationBodies = new ArticulationBody[k_NumRobotJoints];

        var linkName = string.Empty;
        for (var i = 0; i < k_NumRobotJoints; i++)
        {
            linkName += LinkNames[i];
            m_JointArticulationBodies[i] = m_Mycobot.transform.Find(linkName).GetComponent<ArticulationBody>();
        }
        StartCoroutine(PublishJoints(1.0f));
    }

    IEnumerator PublishJoints(float waitSecond)
    {
        while (true)
        {
            var sourceDestinationMessage = new MycobotSetAnglesMsg();

            sourceDestinationMessage.joint_1 = m_JointArticulationBodies[0].jointPosition[0];
            sourceDestinationMessage.joint_2 = m_JointArticulationBodies[1].jointPosition[0];
            sourceDestinationMessage.joint_3 = m_JointArticulationBodies[2].jointPosition[0];
            sourceDestinationMessage.joint_4 = m_JointArticulationBodies[3].jointPosition[0];
            sourceDestinationMessage.joint_5 = m_JointArticulationBodies[4].jointPosition[0];
            sourceDestinationMessage.joint_6 = m_JointArticulationBodies[5].jointPosition[0];
            sourceDestinationMessage.speed = 50;

            // Finally send the message to server_endpoint.py running in ROS
            m_Ros.Publish(m_TopicName, sourceDestinationMessage);
            yield return new WaitForSeconds(waitSecond);
            print(sourceDestinationMessage.ToString());
        }
    }
}
