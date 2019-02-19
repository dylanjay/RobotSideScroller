using UnityEngine;

[RequireComponent(typeof(RobotEventHandler))]
public class RobotAI : MonoBehaviour 
{
    RobotEventHandler eventHandler;

    void Awake()
    {
        eventHandler = GetComponent<RobotEventHandler>();
    }

    void Start()
    {
        eventHandler.hitWall.AddListener(TurnAround);
    }

    void TurnAround()
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(-transform.forward.x, 0f, -transform.forward.z), Vector3.up);
    }
}