﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class RobotLocomotion : MonoBehaviour
{
    CharacterController2D cc;
    Robot robot;

    public float moveSpeed = 3f;
    public float rotateTime = 2f;
    public bool isWalking = true;

    void Awake()
    {
        cc = GetComponent<CharacterController2D>();
        robot = GetComponent<Robot>();
    }

    void Start()
    {
        cc.move(Vector3.up * Physics2D.gravity.y * moveSpeed * Time.deltaTime);
    }

    void Update()
    {
        Walk();
    }

    void Walk()
    {
        if (isWalking)
        {
            Vector3 moveDir = transform.right;
            if (robot.facing == Facing.Left) { moveDir = -transform.right; }
            moveDir += Vector3.up * Physics2D.gravity.y;
            cc.move(moveDir * moveSpeed * Time.deltaTime);
        }
    }

    public void Jump()
    {
         // TODO
    }

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
        robot.free = false;
        if (isWalking)
        {
            while ((robot.facing == Facing.Right && transform.position.x < point) ||
                   (robot.facing == Facing.Left && transform.position.x > point))
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
