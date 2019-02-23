using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStoppers : MonoBehaviour 
{
    Vector3 origin;
    Vector3 destination;
    Vector3 target;
    bool moving = false;
    bool atOrigin = true;

    public Transform bot;
    public Vector3 localDestination;
    public float moveSpeed = 3f;

    void Start()
    {
        origin = transform.position;
        destination = origin + localDestination;
    }

    void Update()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            bot.position = transform.position - Vector3.up;
            if (transform.position == target)
            {
                moving = false;
            }
        }
    }

    public void Flip()
    {
        if (atOrigin)
        {
            MoveTo();
        }
        else
        {
            MoveBack();
        }
    }

    public void MoveTo()
    {
        target = destination;
        moving = true;
        atOrigin = false;
    }

    public void MoveBack()
    {
        target = origin;
        moving = true;
        atOrigin = true;
    }


}