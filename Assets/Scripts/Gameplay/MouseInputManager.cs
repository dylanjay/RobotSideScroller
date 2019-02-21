using UnityEngine;

public class MouseInputManager : MonoBehaviour
{
    public Camera cam;

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
            RaycastHit[] hits = Physics.RaycastAll(ray, float.PositiveInfinity, LayerMask.GetMask("LeftClickable"));
            for (int i = 0; i < hits.Length; i++)
            {
                hits[i].transform.GetComponent<ILeftClickable>().OnClick();
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray, float.PositiveInfinity, LayerMask.GetMask("RightClickable"));
            for (int i = 0; i < hits.Length; i++)
            {
                hits[i].transform.GetComponent<IRightClickable>().OnClick();
            }
        }
    }
}