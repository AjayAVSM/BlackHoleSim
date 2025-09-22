using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;   // The black hole
    public float distance = 10f;
    public float xSpeed = 120f;
    public float ySpeed = 80f;
    public float zoomSpeed = 5f;   // base zoom speed
    public float minZoomFactor = 1.5f; // how close relative to target radius
    public float maxZoomFactor = 50f;  // how far relative to target radius

    private float x = 0f;
    private float y = 0f;

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        if (target == null)
        {
            Debug.LogWarning("CameraController has no target assigned!");
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Orbit with right mouse drag
        if (Input.GetMouseButton(1))
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
        }

        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
        Vector3 position = rotation * negDistance + target.position;

        transform.rotation = rotation;
        transform.position = position;

        // --- Dynamic Zoom ---
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.001f)
        {
            float dynamicSpeed = zoomSpeed * (distance / 10f);

            distance -= scroll * dynamicSpeed;

            // Clamp based on target size
            float targetRadius = target.localScale.magnitude * 0.5f;
            float minZoom = Mathf.Max(2f, targetRadius * minZoomFactor);
            float maxZoom = targetRadius * maxZoomFactor;

            distance = Mathf.Clamp(distance, minZoom, maxZoom);
        }
    }
}
