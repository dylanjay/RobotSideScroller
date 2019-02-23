using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraPanner : MonoBehaviour 
{
    Camera cam;
    Vector2 camExtent;

    public Transform topRightAnchor;
    public Transform botLeftAnchor;
    public float speed = 1.0f;

    void Awake()
    {
        cam = GetComponent<Camera>();
        camExtent = new Vector2(cam.orthographicSize * Screen.width / Screen.height, cam.orthographicSize);
        topRightAnchor.position -= (Vector3)camExtent;
        botLeftAnchor.position += (Vector3)camExtent;
        topRightAnchor.SetParent(transform.parent);
        botLeftAnchor.SetParent(transform.parent);
    }

    void Update()
    {
        float xForce = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        if ((xForce < 0 && transform.position.x <= botLeftAnchor.position.x) || (xForce > 0 && transform.position.x >= topRightAnchor.position.x))
        {
            xForce = 0;
        }
        float yForce = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        if ((yForce < 0 && transform.position.y <= botLeftAnchor.position.y) || (yForce > 0 && transform.position.y >= topRightAnchor.position.y))
        {
            yForce = 0;
        }
        transform.Translate(xForce, yForce, 0f);
    }
}