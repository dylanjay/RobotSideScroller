using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RobotButton : RobotStopTrigger, ILeftClickable, IRightClickable
{
    SpriteOutline outline;
    bool canPress = false;

    public Facing facing = Facing.Right;
    public UnityEvent onPress;

    void Awake()
    {
        outline = GetComponent<SpriteOutline>();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!filled && (other.tag == "Robot" || other.tag == "MainRobot") && other.GetComponent<Robot>().free)
        {
            other.transform.position += Vector3.forward * 4;
            filled = true;
            filledRobot = other.GetComponent<Robot>();
            filledRobot.GetComponent<RobotActivator>().Deactivate();
            StartCoroutine(StopCoroutine(filledRobot));
            canPress = true;
        }
    }

    protected override IEnumerator StopCoroutine(Robot robot)
    {
        yield return robot.GetComponent<RobotLocomotion>().StopMovingCoroutine(transform.position.x);
        robot.GetComponent<RobotRotator>().Face(facing);
    }

    public void OnLeftClick()
    {
        Press();
    }
   
    public void Press()
    {
        if (onPress != null && filled && canPress)
        {
            onPress.Invoke();
        }
    }

    void OnMouseEnter()
    {
        if (filled && canPress)
        {
            outline.outlineOn = true;
        }
    }

    void OnMouseExit()
    {
        outline.outlineOn = false;
    }

    public void OnRightClick()
    {
        filledRobot.transform.position += Vector3.back * 4;
        Release();
        canPress = false;
    }
}