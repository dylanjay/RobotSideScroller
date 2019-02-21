using UnityEngine;
using UnityEngine.Events;

public class RobotButton : RobotStopTrigger, ILeftClickable
{
    public UnityEvent onPress;

    public void OnClick()
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
}