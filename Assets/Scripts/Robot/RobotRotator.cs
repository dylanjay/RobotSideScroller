using System.Collections;
using UnityEngine;

public class RobotRotator : MonoBehaviour 
{
    [HideInInspector]
    public bool isRotating = false;

	public void RotateToOver(Vector3 goal, float length)
    {
        if (isRotating)
        {
            return;
        }

        StartCoroutine(RotateToOverCoroutine(goal, length));
    }

    public IEnumerator RotateToOverCoroutine(Vector3 goal, float length)
    {
        if (!isRotating)
        {
            isRotating = true;
            Quaternion from = transform.rotation;
            Quaternion to = Quaternion.LookRotation(goal, Vector3.up);
            float startTime = Time.time;
            float endTime = startTime + length;
            while (Time.time < endTime)
            {
                transform.rotation = Quaternion.Lerp(from, to, Time.time / endTime);
                yield return null;
            }
            isRotating = false;
        }
    }
}