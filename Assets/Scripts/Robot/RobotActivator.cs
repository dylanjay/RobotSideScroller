using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Robot))]
[RequireComponent(typeof(RobotRotator))]
public class RobotActivator : MonoBehaviour 
{
    Robot robot;
    CharacterController controller;

    void Awake()
    {
        robot = GetComponent<Robot>();
        controller = GetComponent<CharacterController>();
    }

    public void Activate()
    {
        robot.free = true;
    }

    public void Deactivate()
    {
        robot.free = false;
    }
}