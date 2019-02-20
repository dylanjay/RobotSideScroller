using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RobotRotator))]
public class RobotActivator : MonoBehaviour 
{
    public float transitionLength = 2f;

    bool isActive = true;

	public void Deactivate()
    {
        if (!isActive)
        {
            return;
        }
        GetComponent<RobotRotator>().RotateToOver(Vector3.back, 2f);
    }

    public IEnumerator DeactivateCoroutine()
    {
        if (isActive)
        {
            yield return GetComponent<RobotRotator>().RotateToOverCoroutine(Vector3.back, 2f);
        }
    }
}