public class MainRobot : Robot 
{
    RobotLocomotion locomotion;

    void Awake()
    {
        locomotion = GetComponent<RobotLocomotion>();
    }

    public void Begin()
    {
        locomotion.StartMoving();
    }
}