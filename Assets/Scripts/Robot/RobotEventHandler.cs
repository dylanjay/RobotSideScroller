using UnityEngine;
using UnityEngine.Events;

public class HitRobotEvent : UnityEvent<Robot> { }

public class RobotEventHandler : MonoBehaviour 
{
    public int rayDetectionFrameCount = 10;
    public float wallDetectionRayLength = 1.0f;
    public float robotDetectionRayLength = 1.0f;

    public UnityEvent hitWall = new UnityEvent();

    int frameCount = 0;
    Vector3 halfHeightVec;
    Robot robot;

    void Awake()
    {
        robot = GetComponent<Robot>();
    }

    void Start()
    {
        halfHeightVec = new Vector3(0f, GetComponent<BoxCollider2D>().size.y / 2, 0f);
    }

    void Update()
    {
        if (!robot.free)
        {
            return;
        }

        if (frameCount == rayDetectionFrameCount)
        {
            DetectWall();
            frameCount = 0;
        }
        frameCount++;
    }

    void DetectWall()
    {
        if (Physics2D.Raycast(transform.position + halfHeightVec, robot.facing == Facing.Right ? transform.right : -transform.right, wallDetectionRayLength, LayerMask.GetMask("Terrain")))
        {
            hitWall.Invoke();
        }
    }
}