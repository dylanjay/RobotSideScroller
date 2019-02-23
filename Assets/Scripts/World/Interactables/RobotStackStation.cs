using UnityEngine;
using UnityEngine.Events;

public class RobotStackStation : RobotStopTrigger, ILeftClickable
{
    public void OnClick()
    {
        Release();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (filled && other.tag == "Robot")
        {
            filledRobot.GetComponent<RobotStack>().Stack(other.GetComponent<Robot>());
        }
        base.OnTriggerEnter2D(other);
    }
}