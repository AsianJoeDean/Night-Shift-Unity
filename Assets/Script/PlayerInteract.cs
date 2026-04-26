using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; // NEW: Required to talk to the TextMeshPro component

public class PlayerInteract : MonoBehaviour
{
    [Header("Interaction Settings")]
    public float interactDistance = 10f; 
    public DoorController leftDoor; 
    public DoorController rightDoor; 
    public CameraSystem camSystem; 

    [Header("Monitor UI")]
    public TextMeshProUGUI cameraLabel; // NEW: Drag your Monitor's Text object here!

    void Start()
    {
        // Set an initial label so the monitor isn't blank at the start
        if (cameraLabel != null)
        {
            cameraLabel.text = "CAM 1";
        }
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit; 

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                AudioSource clickedAudio = hit.collider.GetComponent<AudioSource>();
                
                if (clickedAudio != null)
                {
                    clickedAudio.Play();
                }

                // --- DOOR BUTTONS ---
                if (hit.collider.gameObject.name == "DoorButton_Left")
                {
                    leftDoor.ToggleDoor(); 
                }
                else if (hit.collider.gameObject.name == "DoorButton_Right")
                {
                    rightDoor.ToggleDoor(); 
                }

                // --- CAMERA BUTTONS ---
                // When we hit Cam 1, switch the feed AND update the label
                else if (hit.collider.gameObject.name == "Button_Cam1")
                {
                    camSystem.SwitchCamera(0);
                    if (cameraLabel != null) cameraLabel.text = "CAM 1";
                }
                // When we hit Cam 2, switch the feed AND update the label
                else if (hit.collider.gameObject.name == "Button_Cam2")
                {
                    camSystem.SwitchCamera(1);
                    if (cameraLabel != null) cameraLabel.text = "CAM 2";
                }
            }
        }
    }
}