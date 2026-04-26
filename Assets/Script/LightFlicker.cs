using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light monitorLight;
    public float minIntensity = 0.4f;
    public float maxIntensity = 0.6f;

    void Update()
    {
        // Randomly jumps the brightness every frame for a subtle "shimmer"
        monitorLight.intensity = Random.Range(minIntensity, maxIntensity);
    }
}