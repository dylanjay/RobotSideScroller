public class MainRobot : Robot 
{
    RobotLocomotion locomotion;

    void Awake()
    {
        locomotion = GetComponent<RobotLocomotion>();
    }

    public void Begin()
    {
        if (GetComponent<Robot>().free && !locomotion.isWalking)
        {
            locomotion.StartMoving();
        }
    }
}