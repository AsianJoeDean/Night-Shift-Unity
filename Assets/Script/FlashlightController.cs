using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightController : MonoBehaviour
{
    public Light flashlight; // The physical light object
    private bool isLightOn = false; // Start with the flashlight off

    [Header("Audio Setup")]
    public AudioSource audioSource; // The speaker
    public AudioClip clickSound;    // The sound file

    void Start()
    {
        // Ensure the light matches our starting state
        flashlight.enabled = isLightOn;
    }

    void Update()
    {
        // Check if the Right Mouse Button was clicked
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            isLightOn = !isLightOn; // Toggle the state
            flashlight.enabled = isLightOn; // Turn the light on/off

            // NEW: Play the click sound
            if (audioSource != null && clickSound != null)
            {
                audioSource.PlayOneShot(clickSound);
            }
        }
    }
}