using System.Collections.Generic;
using UnityEngine;

public class RobotPool : MonoBehaviour 
{
    List<GameObject> robots = new List<GameObject>();

    public int size;

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
                robots.Add(child.gameObject);
            }
        }
        size = robots.Count;
        for (int i = 0; i < robots.Count; i++)
        {
            if (robots[i].activeInHierarchy)
            {
                robots[i].SetActive(false);
            }
            robots[i].transform.SetParent(transform.parent);
        }
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
        robotToReturn.SetActive(true);
        return robotToReturn;
    }

    public void Release(GameObject robot)
    {
        if (robot.tag != "Robot")
        {
            Debug.LogError("Tried to add non-robot object to pool");
            return;
        }
        robot.transform.position = transform.position;
        robot.SetActive(false);
        robots.Add(robot);
        size++;
    }
}