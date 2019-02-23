using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour 
{
    void Start()
    {
        LoadNextLevel();
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
}