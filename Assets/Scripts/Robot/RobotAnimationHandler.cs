﻿using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RobotLocomotion))]
public class RobotAnimationHandler : MonoBehaviour 
{
    Animator anim;
    RobotLocomotion locomotion;
    Robot robot;

    public bool busy = false;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        robot = GetComponent<Robot>();
        locomotion = GetComponent<RobotLocomotion>();
    }

    void Update()
    {
        if (locomotion.isWalking)
        {
            anim.SetFloat("WalkSpeed", 1.0f);
        }
        else
        {
            anim.SetFloat("WalkSpeed", 0f);
        }
    }

    public void Punch(float duration)
    {
        StartCoroutine(PunchCoroutine(duration));
    }

    IEnumerator PunchCoroutine(float duration)
    {
        busy = true;
        anim.SetBool("Punch", true);
        yield return new WaitForSeconds(duration);
        anim.SetBool("Punch", false);
    }

    public void Jump()
    {
        anim.SetTrigger("Jump");
    }
}