using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour 
{
    void Start()
    {
        Debug.Log("Controls:");
        Debug.Log("WASD - Pan Camera");
        Debug.Log("Left Click - Interact");
        Debug.Log("Right Click - Interact (Secondary)");
        Debug.Log("R - Reset Level");
        Debug.Log("F12 - Reset Game");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            ReloadGame();
        }
    }

    public static void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadNextLevelManual()
    {
        LoadNextLevel();
    }
}