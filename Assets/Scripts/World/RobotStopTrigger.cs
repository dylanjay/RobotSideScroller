using UnityEngine;

public class RobotStopTrigger : MonoBehaviour 
{
    [HideInInspector]
    public bool filled = false;

    void OnTriggerEnter(Collider other)
    {
        if (!filled && other.tag == "Robot")
        {
            filled = true;
            other.GetComponent<RobotLocomotion>().StopMoving(transform.position.x);
        }
    }
}