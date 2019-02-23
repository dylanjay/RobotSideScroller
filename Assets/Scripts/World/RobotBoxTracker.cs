using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotBoxTracker : MonoBehaviour 
{
	static Dictionary<int, HashSet<int>> unlocked = new Dictionary<int, HashSet<int>>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static bool IsUnlocked(RobotBox box)
    {
        if (!unlocked.ContainsKey(SceneManager.GetActiveScene().buildIndex))
        {
            return false;
        }
        return unlocked[SceneManager.GetActiveScene().buildIndex].Contains(box.index);
    }

    public static void Unlock(RobotBox box)
    {
        if (!unlocked.ContainsKey(SceneManager.GetActiveScene().buildIndex))
        {
            unlocked.Add(SceneManager.GetActiveScene().buildIndex, new HashSet<int>());
        }
        if (unlocked[SceneManager.GetActiveScene().buildIndex].Contains(box.GetInstanceID()))
        {
            return;
        }
        unlocked[SceneManager.GetActiveScene().buildIndex].Add(box.index);
    }
}