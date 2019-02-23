using UnityEngine;
using UnityEngine.Events;

public class RobotButton : RobotStopTrigger, ILeftClickable, IRightClickable
{
    SpriteOutline outline;

    public UnityEvent onPress;

    void Awake()
    {
        outline = GetComponent<SpriteOutline>();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!filled && (other.tag == "Robot" || other.tag == "MainRobot"))
        {
            other.transform.position += Vector3.forward * 4;
            filled = true;
            filledRobot = other.GetComponent<Robot>();
            filledRobot.GetComponent<RobotActivator>().Deactivate();
            StartCoroutine(StopCoroutine(filledRobot));
        }
    }

    public void OnLeftClick()
    {
        Press();
    }
   
    public void Press()
    {
        if (onPress != null && filled)
        {
            onPress.Invoke();
        }
    }

    void OnMouseEnter()
    {
        if (filled)
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
    }
}