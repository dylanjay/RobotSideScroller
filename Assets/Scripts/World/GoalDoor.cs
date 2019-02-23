using System.Collections;
using UnityEngine;

public class GoalDoor : RobotStopTrigger
{
    bool open = false;
    SpriteRenderer spriteRenderer;

    public Sprite openSprite;
    public Sprite closedSprite;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Open()
    {
        open = true;
        spriteRenderer.sprite = openSprite;
    }

    public void Close()
    {
        open = false;
        spriteRenderer.sprite = closedSprite;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (open && other.tag == "MainRobot")
        {
            StartCoroutine(GoalSequence(other.gameObject));
        }
    }

    IEnumerator GoalSequence(GameObject robot)
    {
        if (robot.GetComponent<Robot>().free)
        {
            robot.transform.position = robot.transform.position + Vector3.back * 2;
            yield return robot.GetComponent<RobotLocomotion>().StopMovingCoroutine(transform.position.x);
            yield return robot.GetComponent<RobotRotator>().RotateToOverCoroutine(Vector3.forward, 2f);
            //TODO : Transition to next level
            Debug.Log("LEVEL COMPLETE");
        }
    }
}