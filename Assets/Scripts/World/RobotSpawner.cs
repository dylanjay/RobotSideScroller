﻿using System.Collections;
using UnityEngine;

public class RobotSpawner : MonoBehaviour, ILeftClickable
{
    bool canSpawn = true;
    Facing facing = Facing.Right;
    float yExtent;

    public RobotPool pool;
    public float cooldown = 1.0f;

    void Start()
    {
        if (pool == null)
        {
            Debug.LogError("Robot bool is null in spawner");
        }
        yExtent = GetComponent<BoxCollider2D>().size.y / 2 * transform.localScale.y;
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
        // TODO : flip
        GameObject robot = pool.Extract();
        robot.SetActive(true);
        robot.transform.position = transform.position - Vector3.up * yExtent;
        StartCoroutine(Cooldown());
    }

    public void Flip()
    {
        if (facing == Facing.Right)
        {
            facing = Facing.Left;
        }
        else if (facing == Facing.Left)
        {
            facing = Facing.Right;
        }
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