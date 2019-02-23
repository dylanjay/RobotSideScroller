using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    public LayerMask mask;
    Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("cam in MouseInputManager is null");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, float.PositiveInfinity, mask);
            for (int i = 0; i < hits.Length; i++)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ILeftClickable[] leftClicks = hits[i].transform.GetComponents<ILeftClickable>();
                    foreach (ILeftClickable leftClick in leftClicks)
                    {
                        leftClick.OnLeftClick();
                    }
                }
                else
                {
                    IRightClickable[] rightClicks = hits[i].transform.GetComponents<IRightClickable>();
                    foreach (IRightClickable rightClick in rightClicks)
                    {
                        rightClick.OnRightClick();
                    }
                }
            }
        }
    }
}