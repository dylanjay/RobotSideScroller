using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, float.PositiveInfinity, LayerMask.GetMask("LeftClickable"));
            for (int i = 0; i < hits.Length; i++)
            {
                hits[i].transform.GetComponent<ILeftClickable>().OnClick();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, float.PositiveInfinity, LayerMask.GetMask("RightClickable"));
            for (int i = 0; i < hits.Length; i++)
            {
                hits[i].transform.GetComponent<IRightClickable>().OnClick();
            }
        }
    }
}