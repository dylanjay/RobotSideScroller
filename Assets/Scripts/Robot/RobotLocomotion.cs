using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RobotLocomotion : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotateTime = 2f;

    [HideInInspector]
    public bool isWalking = true;

    CharacterController cc;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        Walk();

        //if (cc.isGrounded)
        //{
        //    Walk();
        //}
        //else
        //{
        //    Jump();
        //}
    }

    void Walk()
    {
        if (isWalking)
        {
            cc.SimpleMove(transform.forward * moveSpeed);
        }
    }

    public void Jump()
    {
         // TODO
    }

    public delegate void OnStopComplete();

    public void StopMoving(float point)
    {
        if (!isWalking)
        {
            return;
        }
        StartCoroutine(StopMovingCoroutine(point));
    }

    public IEnumerator StopMovingCoroutine(float point)
    {
        if (isWalking)
        {
            int walkingDir = (int)Mathf.Sign(transform.forward.x);
            while ((walkingDir > 0 && transform.position.x < point) ||
                   (walkingDir < 0 && transform.position.x > point))
            {
                yield return null;
            }
            isWalking = false;
        }
    }

    public void StartMoving()
    {
        isWalking = true;
    }
}
