using System.Collections;
using UnityEngine;

public class RobotGoalTrigger : RobotStopTrigger
{
    public LevelGoalManager goalManager;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!filled && other.tag == "Robot" && other.GetComponent<Robot>().free)
        {
            StartCoroutine(GoalSequence(other.gameObject));
            filled = true;
            filledRobot = other.GetComponent<Robot>();
        }
    }

    IEnumerator GoalSequence(GameObject robot)
    {
        if (robot.GetComponent<Robot>().free)
        {
            robot.transform.position = robot.transform.position + Vector3.forward * 2;
            yield return robot.GetComponent<RobotLocomotion>().StopMovingCoroutine(transform.position.x);
            yield return robot.GetComponent<RobotRotator>().RotateToOverCoroutine(Vector3.back, 2f);
            goalManager.GoalIncrement();
        }
    }
}