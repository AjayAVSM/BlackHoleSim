using UnityEngine;

public class SimpleAccretionDisk : MonoBehaviour
{
    public GameObject particlePrefab;
    public int numParticles = 500;
    public Transform blackHole;
    public float outerRadius = 3f;       // only outer radius is adjustable
    public float rotationSpeed = 30f;    // degrees per second

    private GameObject[] particles;
    private float[] angles;
    private float[] radii;

    void Start()
    {
        if (blackHole == null || particlePrefab == null) return;

        particles = new GameObject[numParticles];
        angles = new float[numParticles];
        radii = new float[numParticles];

        for (int i = 0; i < numParticles; i++)
        {
            // Inner radius = black hole scale (x axis)
            float innerRadius = blackHole.localScale.x * 0.5f;

            // Random radius between black hole surface and outerRadius
            radii[i] = Random.Range(innerRadius, outerRadius);
            angles[i] = Random.Range(0f, 360f);

            // Position in XZ plane
            Vector3 pos = new Vector3(
                radii[i] * Mathf.Cos(angles[i] * Mathf.Deg2Rad),
                0f,
                radii[i] * Mathf.Sin(angles[i] * Mathf.Deg2Rad)
            ) + blackHole.position;

            particles[i] = Instantiate(particlePrefab, pos, Quaternion.identity, transform);
        }
    }

    void Update()
    {
        float dt = Time.deltaTime;

        // Update inner radius dynamically in case black hole scale changes
        float innerRadius = blackHole.localScale.x * 0.5f;

        for (int i = 0; i < numParticles; i++)
        {
            // Keep radius relative to black hole size
            if (radii[i] < innerRadius) radii[i] = innerRadius;

            angles[i] += rotationSpeed * dt; // rotate particle
            float rad = angles[i] * Mathf.Deg2Rad;
            Vector3 pos = new Vector3(
                radii[i] * Mathf.Cos(rad),
                0f,
                radii[i] * Mathf.Sin(rad)
            ) + blackHole.position;

            particles[i].transform.position = pos;
        }
    }
}
