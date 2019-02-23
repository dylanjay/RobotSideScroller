using System.Collections;
using UnityEngine;

public class RobotSpawner : MonoBehaviour, ILeftClickable
{
    bool canSpawn = true;
    Facing facing = Facing.Right;
    float yExtent;
    SpriteOutline outline;

    public RobotPool pool;
    public float cooldown = 1.0f;

    void Awake()
    {
        outline = GetComponent<SpriteOutline>();
    }

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
        if (!canSpawn || pool.size <= 0)
        {
            return;
        }
        GameObject robot = pool.Extract();
        robot.GetComponent<RobotRotator>().Face(facing);
        robot.SetActive(true);
        robot.transform.position = transform.position - Vector3.up * yExtent + Vector3.back * 2;
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

    public void OnLeftClick()
    {
        Spawn();
    }

    void OnMouseEnter()
    {
        if (canSpawn && pool.size > 0)
        {
            outline.outlineOn = true;
        }
    }
    
    void OnMouseExit()
    {
        outline.outlineOn = false;
    }
}