using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [Header("Target")]
    public Transform target;
    public float distance = 5.0f;
    public float minDistance = 1.0f;
    public float maxDistance = 20.0f;

    [Header("Rotation")]
    public float xSpeed = 120f;
    public float ySpeed = 80f;
    public float yMinLimit = -20f;
    public float yMaxLimit = 80f;

    [Header("Zoom")]
    public float zoomSpeed = 2f;
    public float smoothTime = 0.2f;

    [Header("Vertical Offset (Q/E)")]
    public float verticalSpeed = 2f;      // speed of vertical shift
    public float verticalLimit = 2f;      // max up/down movement
    private float verticalOffset = 0f;    // current offset

    private float x = 0.0f;
    private float y = 25.0f;
    private float currentDistance;
    private float zoomVelocity = 0.0f;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("OrbitCamera: No target assigned!");
            enabled = false;
            return;
        }

        //Vector3 angles = transform.eulerAngles;
        //x = angles.y;
        //y = angles.x;
        x = 0f;          // facing forward (can set another if you want yaw offset)
        y = 5.0f;       // starting tilt upwards
        currentDistance = distance;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // --- Rotation: mouse drag ---
        if (Input.GetMouseButton(0))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
            y -= Input.GetAxis("Mouse Y") * ySpeed * Time.deltaTime;
            y = Mathf.Clamp(y, yMinLimit, yMaxLimit);
        }

        // --- Rotation: keyboard ---
        if (Input.GetKey(KeyCode.A)) x -= xSpeed * Time.deltaTime * 0.5f;
        if (Input.GetKey(KeyCode.D)) x += xSpeed * Time.deltaTime * 0.5f;
        if (Input.GetKey(KeyCode.W)) y += ySpeed * Time.deltaTime * 0.5f;
        if (Input.GetKey(KeyCode.S)) y -= ySpeed * Time.deltaTime * 0.5f;

        y = Mathf.Clamp(y, yMinLimit, yMaxLimit);

        // --- Zoom: scroll wheel ---
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            float targetDistance = currentDistance - scroll * zoomSpeed;
            targetDistance = Mathf.Clamp(targetDistance, minDistance, maxDistance);
            currentDistance = Mathf.SmoothDamp(currentDistance, targetDistance, ref zoomVelocity, smoothTime);
        }

        // --- Zoom: keyboard keys (Z/X) ---
        if (Input.GetKey(KeyCode.Z))
            currentDistance = Mathf.Max(minDistance, currentDistance - zoomSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.X))
            currentDistance = Mathf.Min(maxDistance, currentDistance + zoomSpeed * Time.deltaTime);

        // --- Vertical offset with Q/E ---
        if (Input.GetKey(KeyCode.E))
            verticalOffset = Mathf.Clamp(verticalOffset + verticalSpeed * Time.deltaTime, -verticalLimit, verticalLimit);
        if (Input.GetKey(KeyCode.Q))
            verticalOffset = Mathf.Clamp(verticalOffset - verticalSpeed * Time.deltaTime, -verticalLimit, verticalLimit);

        // --- Apply transform ---
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * new Vector3(0.0f, verticalOffset, -currentDistance) + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }
}
