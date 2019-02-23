using UnityEngine;

public class LevelGoalManager : MonoBehaviour 
{
    public int goalsNeeded = 1;
    public GoalDoor door;
    int curGoals = 0;

    void Start()
    {
        if (door == null)
        {
            Debug.LogError("Door is null in LevelGoalManager");
        }
    }

    public void GoalIncrement()
    {
        curGoals++;
        if (curGoals >= goalsNeeded)
        {
            door.Open();
        }
    }

    public void GoalDecrement()
    {
        if (curGoals == 0)
        {
            Debug.LogError("Tried to decrement goals when cur is 0");
            return;
        }

        curGoals--;
    }
}