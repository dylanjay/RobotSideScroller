using System.Collections;
using UnityEngine;

public class RobotBox : RobotStopTrigger 
{
    RobotBoxShake shake;

    public int index = 0;
    public GameObject hiddenRobot;
    public RobotPool pool;
    public Transform leftStop;
    public Transform rightStop;
    public float timer = 3f;
    public float punchFrontPad;

    void Awake()
    {
        shake = GetComponent<RobotBoxShake>();
    }

    void Start()
    {
        if (RobotBoxTracker.IsUnlocked(this))
        {
            pool.Release(hiddenRobot);
            gameObject.SetActive(false);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (!filled && (other.tag == "Robot" || other.tag == "MainRobot"))
        {
            filled = true;
            filledRobot = other.GetComponent<Robot>();
            filledRobot.GetComponent<RobotActivator>().Deactivate();
            StartCoroutine(UnlockRobot(filledRobot));
        }
    }

    IEnumerator UnlockRobot(Robot robot)
    {
        RobotBoxTracker.Unlock(this);
        float stopPos = Mathf.Abs(leftStop.position.x - robot.transform.position.x) < Mathf.Abs(rightStop.position.x - robot.transform.position.x) ? leftStop.position.x : rightStop.position.x;
        yield return robot.GetComponent<RobotLocomotion>().StopMovingCoroutine(stopPos);
        robot.GetComponent<RobotAnimationHandler>().Punch(timer);
        yield return new WaitForSeconds(punchFrontPad);
        shake.Stress();
        yield return new WaitForSeconds(timer - punchFrontPad);
        pool.Release(hiddenRobot);
        Release();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public override void Release()
    {
        StartCoroutine(ReleaseCoroutine());
    }

    IEnumerator ReleaseCoroutine()
    {
        while (filledRobot.GetComponent<RobotAnimationHandler>().busy)
        {
            yield return null;
        }
        filledRobot.GetComponent<RobotLocomotion>().StartMoving();
        filledRobot.GetComponent<RobotActivator>().Activate();
    }
}