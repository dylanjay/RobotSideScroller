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
    }

    void Update()
    {
        float xForce = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        if (transform.position.x <= botLeftAnchor.position.x || transform.position.x >= topRightAnchor.position.x)
        {
            xForce = 0;
        }
        float yForce = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        if (transform.position.y <= botLeftAnchor.position.y || transform.position.y >= topRightAnchor.position.y)
        {
            yForce = 0;
        }
        transform.Translate(xForce, yForce, 0f);
        //Vector3 camPos = transform.position;
        //camPos += new Vector3(camPos.x + (Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime), camPos.y + Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);
        //Debug.Log(camPos + " " + (Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime));
        //camPos.x = Mathf.Clamp(camPos.x, botLeftAnchor.position.x, topRightAnchor.position.x);
        //camPos.y = Mathf.Clamp(camPos.y, botLeftAnchor.position.y, topRightAnchor.position.y);
        //transform.position = camPos;
    }
}