using System.Collections;
using UnityEngine;

public class RobotStopTrigger : MonoBehaviour 
{
    [HideInInspector]
    public bool filled = false;

    protected Robot filledRobot;

    public float cooldown = 3f;

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!filled && (other.tag == "Robot" || other.tag == "MainRobot"))
        {
            filled = true;
            filledRobot = other.GetComponent<Robot>();
            filledRobot.GetComponent<RobotActivator>().Deactivate();
            StartCoroutine(StopCoroutine(filledRobot));
        }
    }

    protected virtual IEnumerator StopCoroutine(Robot robot)
    {
        yield return robot.GetComponent<RobotLocomotion>().StopMovingCoroutine(transform.position.x);
    }

    public virtual void Release()
    {
        filledRobot.GetComponent<RobotLocomotion>().StartMoving();
        filledRobot.GetComponent<RobotActivator>().Activate();
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        filled = false;
        filledRobot = null;
    }
}