using UnityEngine;
using TMPro; // NEW: We need this to edit TextMeshPro UI!

public class DoorController : MonoBehaviour
{
    [Header("Door Settings")]
    public float openHeight = 4.5f;
    public float closedHeight = 1.5f;
    public float doorSpeed = 5f;

    [Header("Power Settings")]
    public float maxPower = 100f;
    public float currentPower;
    public float powerDrainRate = 10f; 

    [Header("UI Settings (NEW)")]
    public TextMeshProUGUI powerText; 
    public string doorLabel = "Left Door"; // Change this in the Inspector for the right door!

    [Header("Audio Settings")]
    public AudioSource doorSound; 

    public bool isOpen = true;
    private Vector3 targetPosition;

    void Start()
    {
        currentPower = maxPower; 
        targetPosition = new Vector3(transform.position.x, openHeight, transform.position.z);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * doorSpeed);

        if (!isOpen)
        {
            currentPower -= powerDrainRate * Time.deltaTime;

            if (currentPower <= 0)
            {
                currentPower = 0;
                ForceOpenDoor();
            }
        }

        // NEW: Update the UI text every single frame
        if (powerText != null)
        {
            // Mathf.RoundToInt removes the decimals so it looks like a clean percentage!
            powerText.text = doorLabel + ": " + Mathf.RoundToInt(currentPower) + "%";
        }
    }

    public void ToggleDoor()
    {
        if (currentPower <= 0) return;

        isOpen = !isOpen; 
        
        if (doorSound != null) doorSound.Play();
        
        if (isOpen)
        {
            targetPosition = new Vector3(transform.position.x, openHeight, transform.position.z);
        }
        else
        {
            targetPosition = new Vector3(transform.position.x, closedHeight, transform.position.z);
        }
    }

    private void ForceOpenDoor()
    {
        if (!isOpen) 
        {
            if (doorSound != null) doorSound.Play();
        }
        
        isOpen = true;
        targetPosition = new Vector3(transform.position.x, openHeight, transform.position.z);
    }
}