using System.Collections;
using UnityEngine;

public class RobotSpawner : MonoBehaviour, ILeftClickable
{
    bool canSpawn = true;

    public RobotPool pool;
    public float cooldown = 1.0f;

    void Start()
    {
        if (pool == null)
        {
            Debug.LogError("Robot bool is null in spawner");
        }
    }

    public void Spawn()
    {
        if (!canSpawn)
        {
            return;
        }

        if (pool.size <= 0)
        {
            Debug.Log("Tried to spawn while pool is empty");
            return;
        }

        GameObject robot = pool.Extract();
        robot.transform.position = transform.position;
        
    }

    IEnumerator Cooldown()
    {
        canSpawn = false;
        yield return new WaitForSeconds(cooldown);
        canSpawn = true;
    }

    public void OnClick()
    {
        Spawn();
    }
}