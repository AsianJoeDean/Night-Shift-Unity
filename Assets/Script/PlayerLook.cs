using UnityEngine;
using UnityEngine.InputSystem; // This line tells the script to use the New Input System!

public class PlayerLook : MonoBehaviour
{
    [Header("Look Settings")]
    public float mouseSensitivity = 15f; 
    
    float xRotation = 0f;
    float yRotation = 0f;

    void Start()
    {
        // This hides your mouse cursor and locks it to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Failsafe: If no mouse is plugged in, don't try to read it and cause an error
        if (Mouse.current == null) return;

        // Read the exact pixel movement of the mouse from the New Input System
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        // Apply sensitivity and Time.deltaTime to keep the speed smooth
        float mouseX = mouseDelta.x * mouseSensitivity * Time.deltaTime;
        float mouseY = mouseDelta.y * mouseSensitivity * Time.deltaTime;

        // Calculate up/down looking and clamp it
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -35f, 35f);

        // Calculate left/right looking and clamp it
        yRotation += mouseX;
        yRotation = Mathf.Clamp(yRotation, -110f, 110f);

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}