using UnityEngine;

public class LevelGoalManager : MonoBehaviour 
{
    public int goalsNeeded = 1;

    int curGoals = 0;

    public void GoalIncrement()
    {
        curGoals++;

        if (curGoals >= goalsNeeded)
        {
            //TODO progress to next level
            Debug.Log("Goal Complete!");
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