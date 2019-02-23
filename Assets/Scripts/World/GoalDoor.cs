using System.Collections;
using UnityEngine;

public class GoalDoor : RobotStopTrigger
{
    public bool open = false;
    SpriteRenderer spriteRenderer;
    SpriteRenderer stripesRenderer;

    public Sprite openSprite;
    public Sprite closedSprite;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        stripesRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        if (open)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    public void Open()
    {
        open = true;
        spriteRenderer.sprite = openSprite;
        stripesRenderer.enabled = false;
    }

    public void Close()
    {
        open = false;
        spriteRenderer.sprite = closedSprite;
        stripesRenderer.enabled = true;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (open && other.tag == "MainRobot" && other.GetComponent<Robot>().free)
        {
            StartCoroutine(GoalSequence(other.gameObject));
        }
    }

    IEnumerator GoalSequence(GameObject robot)
    {
        if (robot.GetComponent<Robot>().free)
        {
            yield return robot.GetComponent<RobotLocomotion>().StopMovingCoroutine(transform.position.x);
            yield return robot.GetComponent<RobotRotator>().RotateToOverCoroutine(Vector3.forward, 2f);
            LevelLoader.LoadNextLevel();
        }
    }
}