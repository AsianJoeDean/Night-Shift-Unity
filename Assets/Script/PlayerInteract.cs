using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactDistance = 10f; 
    public DoorController leftDoor; 
    public CameraSystem camSystem; // We added a link to your new Camera System!

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit; 

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                // If we hit the door button...
                if (hit.collider.gameObject.name == "DoorButton")
                {
                    leftDoor.ToggleDoor(); 
                }
                // If we hit the Cam1 button... (Index 0)
                else if (hit.collider.gameObject.name == "Button_Cam1")
                {
                    camSystem.SwitchCamera(0);
                }
                // If we hit the Cam2 button... (Index 1)
                else if (hit.collider.gameObject.name == "Button_Cam2")
                {
                    camSystem.SwitchCamera(1);
                }
            }
        }
    }
}