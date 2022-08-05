using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.MycobotCommunication;
using UnityEngine;

public class MycobotRosController : MonoBehaviour
{
    
    [SerializeField]
    GameObject m_Mycobot;

    // Hardcoded variables
    const int k_NumRobotJoints = 6;
    public static readonly string[] LinkNames =
        { "joint1/joint2", "/joint3", "/joint4", "/joint5", "/joint6", "/joint6_flange" };

    ArticulationBody[] m_JointArticulationBodies;

    // Variables required for ROS communication
    ROSConnection m_Ros;
    public string m_PublishTopicName = "mycobot/angles_goal";
    public string m_SubscribeTopicName = "mycobot/angles_real";

    // Start is called before the first frame update
    void Start()
    {
        // Get ROS connection static instance
        m_Ros = ROSConnection.GetOrCreateInstance();
        m_Ros.RegisterPublisher<MycobotSetAnglesMsg>(m_PublishTopicName);
        m_Ros.Subscribe<MycobotAnglesMsg>(m_SubscribeTopicName, SubscribeTopic);

        m_JointArticulationBodies = new ArticulationBody[k_NumRobotJoints];

        var linkName = string.Empty;
        for (var i = 0; i < k_NumRobotJoints; i++)
        {
            linkName += LinkNames[i];
            m_JointArticulationBodies[i] = m_Mycobot.transform.Find(linkName).GetComponent<ArticulationBody>();
        }
        StartCoroutine(PublishTopic(2.0f));
    }

    IEnumerator PublishTopic(float waitSecond)
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
            m_Ros.Publish(m_PublishTopicName, sourceDestinationMessage);
            yield return new WaitForSeconds(waitSecond);
        }
    }

    void SubscribeTopic(MycobotAnglesMsg msg) {
        Debug.Log("Heard");
        Debug.Log(msg.ToString());
    }
}
