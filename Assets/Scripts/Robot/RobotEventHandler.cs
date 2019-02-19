using UnityEngine;
using UnityEngine.Events;

public class RobotEventHandler : MonoBehaviour 
{
    public int rayDetectionFrameCount = 10;
    public float wallDetectionRayLength = 1.0f;

    [HideInInspector]
    public UnityEvent hitWall = new UnityEvent();

    int frameCount = 0;
    Vector3 halfHeightVec;
    

    void Start()
    {
        halfHeightVec = new Vector3(0f, GetComponent<CharacterController>().height / 2, 0f);
    }

    void Update()
    {
        if (frameCount == rayDetectionFrameCount)
        {
            DetectWall();
            frameCount = 0;
        }
        frameCount++;
    }

    void DetectWall()
    {
        if (Physics.Raycast(transform.position, transform.forward, wallDetectionRayLength, LayerMask.GetMask("Terrain")))
        {
            hitWall.Invoke();
        }
    }
}