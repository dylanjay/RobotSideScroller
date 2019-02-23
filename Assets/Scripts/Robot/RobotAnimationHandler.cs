using UnityEngine;

[RequireComponent(typeof(RobotLocomotion))]
public class RobotAnimationHandler : MonoBehaviour 
{
    Animator anim;
    RobotLocomotion locomotion;
    Robot robot;

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
}