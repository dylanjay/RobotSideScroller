using UnityEngine;

public enum Facing { Left, Right }

public class Robot : MonoBehaviour 
{
    public bool free = true;
    public Facing facing = Facing.Right;
}