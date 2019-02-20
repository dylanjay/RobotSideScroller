using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RobotGoalTrigger : RobotStopTrigger
{
    public LevelGoalManager goalManager;

    //BoxCollider boxCollider;

    //void Awake()
    //{
    //    boxCollider = GetComponent<BoxCollider>();
    //}

    void OnTriggerEnter(Collider other)
    {
        if (!filled && other.tag == "Robot")
        {
            StartCoroutine(GoalSequence(other.gameObject));
            filled = true;
        }
    }

    IEnumerator GoalSequence(GameObject robot)
    {
        yield return robot.GetComponent<RobotLocomotion>().StopMovingCoroutine(transform.position.x);
        yield return robot.GetComponent<RobotActivator>().DeactivateCoroutine();
        goalManager.GoalIncrement();
    }
    

    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawCube(transform.position + boxCollider.center, boxCollider.size);
    //}
}