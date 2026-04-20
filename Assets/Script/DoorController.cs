using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Door Settings")]
    public float openHeight = 4.5f;
    public float closedHeight = 1.5f;
    public float doorSpeed = 5f;

    public bool isOpen = true;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = new Vector3(transform.position.x, openHeight, transform.position.z);
    }

    void Update()
    {
        // The door now ONLY focuses on smoothly sliding to its target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * doorSpeed);
    }

    // This is a custom command we can call from our Raycast script!
    public void ToggleDoor()
    {
        isOpen = !isOpen; 
        
        if (isOpen)
        {
            targetPosition = new Vector3(transform.position.x, openHeight, transform.position.z);
        }
        else
        {
            targetPosition = new Vector3(transform.position.x, closedHeight, transform.position.z);
        }
    }
}