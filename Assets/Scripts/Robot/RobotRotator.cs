using System.Collections;
using UnityEngine;

public class RobotRotator : MonoBehaviour 
{
    [HideInInspector]
    public bool isRotating = false;

    Transform pivot;

    void Awake()
    {
        pivot = transform.GetChild(0);
        if (pivot == null)
        {
            Debug.LogError("Pivot is null in robot rotator");
        }
    }

    public void RotateToOver(Vector3 goal, float length)
    {
        if (isRotating)
        {
            return;
        }

        StartCoroutine(RotateToOverCoroutine(goal, length));
    }

    public void Face(Facing facing)
    {
        switch (facing)
        {
            case Facing.Left:
                transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up);
                break;
            case Facing.Right:
                transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up);
                break;
        }
    }

    public IEnumerator RotateToOverCoroutine(Vector3 goal, float length)
    {
        if (!isRotating)
        {
            isRotating = true;
            Quaternion from = pivot.rotation;
            Quaternion to = Quaternion.LookRotation(goal, Vector3.up);
            float startTime = Time.time;
            float endTime = startTime + length;
            while (Time.time < endTime)
            {
                pivot.rotation = Quaternion.Lerp(from, to, (Time.time - startTime) / length);
                yield return null;
            }
            isRotating = false;
        }
    }
}