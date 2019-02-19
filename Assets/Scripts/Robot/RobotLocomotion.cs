using UnityEngine;

public class RobotLocomotion : MonoBehaviour
{
    public float moveSpeed = 3f;

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

    public void StopMoving()
    {
        isWalking = false;
    }

    public void StartMoving()
    {
        isWalking = true;
    }
}
