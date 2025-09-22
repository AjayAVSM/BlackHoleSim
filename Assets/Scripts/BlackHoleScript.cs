using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [Header("Black Hole Settings")]
    public float mass = 10f;   // can change this in Inspector
    public float G = 1f;       // scaled gravity
    public float c = 10f;      // fake speed of light (not real units, just for scaling)

    void Update()
    {
        // Calculate Schwarzschild radius
        float Rs = (2f * G * mass) / (c * c);

        // Scale the sphere to match diameter
        transform.localScale = new Vector3(Rs * 2f, Rs * 2f, Rs * 2f);
    }
}
