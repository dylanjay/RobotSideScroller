using UnityEngine;

[RequireComponent(typeof(RobotLocomotion))]
public class RobotAnimationHandler : MonoBehaviour 
{
    Animator anim;
    RobotLocomotion locomotion;

    void Awake()
    {
        anim = GetComponent<Animator>();
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