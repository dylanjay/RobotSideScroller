using System.Collections;
using UnityEngine;

public class RobotStopTrigger : MonoBehaviour 
{
    [HideInInspector]
    public bool filled = false;

    protected Robot filledRobot;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!filled && other.tag == "Robot")
        {
            filled = true;
            filledRobot = other.GetComponent<Robot>();
            StartCoroutine(StopCoroutine(filledRobot));
        }
    }

    IEnumerator StopCoroutine(Robot robot)
    {
        yield return robot.GetComponent<RobotLocomotion>().StopMovingCoroutine(transform.position.x);
        robot.GetComponent<RobotActivator>().Deactivate();
    }

    void OnTriggerExit(Collider other)
    {
        if (filled && other.tag == "Robot" && other.GetComponent<Robot>() == filledRobot && other.GetComponent<Robot>().free)
        {
            filled = false;
            filledRobot = null;
        }
    }

    public void Release()
    {
        filledRobot.GetComponent<RobotLocomotion>().StartMoving();
        filledRobot.GetComponent<RobotActivator>().Activate();
    }
}