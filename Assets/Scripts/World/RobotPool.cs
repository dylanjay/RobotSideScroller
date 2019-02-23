using System.Collections.Generic;
using UnityEngine;

public class RobotPool : MonoBehaviour 
{
    List<GameObject> robots = new List<GameObject>();

    public int size;
    public int gap;

    void Start()
    {
        FillPool();
    }

    void FillPool()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.tag == "Robot")
            {
                Release(child.gameObject);
            }
        }
        size = robots.Count;
    }

    public GameObject Extract()
    {
        if (size <= 0)
        {
            return null;
        }

        GameObject robotToReturn = robots[size - 1];
        robots.RemoveAt(size - 1);
        size--;
        robotToReturn.GetComponent<RobotLocomotion>().isWalking = true;
        robotToReturn.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        robotToReturn.GetComponent<Robot>().free = true;
        robotToReturn.transform.SetParent(transform.parent.parent);
        robotToReturn.transform.localScale = Vector3.one;
        return robotToReturn;
    }

    public void Release(GameObject robot)
    {
        if (robot.tag != "Robot")
        {
            Debug.LogError("Tried to add non-robot object to pool");
            return;
        }
        robots.Add(robot);
        robot.GetComponent<RobotLocomotion>().isWalking = false;
        robot.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        robot.GetComponent<Robot>().free = false;
        robot.transform.SetParent(transform);
        robot.transform.localScale = Vector3.one;
        robot.transform.position = transform.position + Vector3.right * (size * (gap + robot.GetComponent<BoxCollider2D>().size.x * robot.transform.localScale.x));
        size++;
    }
}