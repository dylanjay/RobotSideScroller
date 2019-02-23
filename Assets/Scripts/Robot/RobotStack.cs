using System.Collections.Generic;
using UnityEngine;

public class RobotStack : MonoBehaviour 
{
    LinkedList<Robot> stack = new LinkedList<Robot>();

    BoxCollider2D boxCollider;
    float gap;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        stack.AddLast(GetComponent<Robot>());
        gap = boxCollider.size.y;
    }

    public void Stack(Robot robot)
    {
        LinkedList<Robot> stackToCombine = robot.GetComponent<RobotStack>().stack;
        LinkedListNode<Robot> cur = stackToCombine.Last;
        while (cur != null)
        {
            Robot curRobot = cur.Value;
            curRobot.GetComponent<RobotActivator>().Deactivate();
            curRobot.transform.SetParent(stack.First.Value.transform);
            curRobot.transform.rotation = transform.rotation;
            curRobot.transform.localPosition = new Vector3(0, gap, 0);
            stack.AddFirst(curRobot);
            cur = cur.Previous;
        }
        ExtendCollider();
    }

    void ExtendCollider()
    {
        //TODO
    }


}