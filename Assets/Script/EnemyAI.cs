using UnityEngine;
using System.Collections; 

public class EnemyAI : MonoBehaviour
{
    [Header("Hunting Settings")]
    public Transform targetDoor; 
    public DoorController doorScript; 
    public float creepSpeed = 1.0f; 
    
    [Header("Attack Settings")]
    public float attackDistance = 2.0f; 
    public float waitTimeAtDoor = 3.0f; 

    [Header("Game Over System")]
    public GameOverManager gameManager; 
    
    private Vector3 startPosition; 
    private bool isWaiting = false; 
    private bool hasTriggeredJumpscare = false;

    void Start()
    {
        // Memorize exactly where it spawned so it can teleport back here later
        startPosition = transform.position;
    }

    void Update()
    {
        // Stop moving if the game is over, or if we are waiting at a door
        if (targetDoor == null || isWaiting || hasTriggeredJumpscare) return;

        // Lock Y-axis to 0 so we measure true floor distance (fixes the "ghost" bug)
        Vector3 enemyFlatPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 doorFlatPos = new Vector3(targetDoor.position.x, 0, targetDoor.position.z);

        float distanceToDoor = Vector3.Distance(enemyFlatPos, doorFlatPos);

        // Did we reach the door?
        if (distanceToDoor <= attackDistance)
        {
            if (doorScript.isOpen)
            {
                // Door is open! You lose.
                TriggerJumpscare();
            }
            else
            {
                // Door is closed! Wait, then leave.
                StartCoroutine(WaitAndLeave());
            }
        }
        else
        {
            // Keep walking (keeping feet firmly on the floor!)
            Vector3 groundTarget = new Vector3(targetDoor.position.x, transform.position.y, targetDoor.position.z);
            transform.position = Vector3.MoveTowards(transform.position, groundTarget, creepSpeed * Time.deltaTime);
        }
    }

    IEnumerator WaitAndLeave()
    {
        isWaiting = true; 
        Debug.Log("Enemy hit a closed door. Waiting...");
        
        yield return new WaitForSeconds(waitTimeAtDoor); 
        
        Debug.Log("Enemy gave up and returned to start.");
        transform.position = startPosition; 
        isWaiting = false; 
    }

    void TriggerJumpscare()
    {
        hasTriggeredJumpscare = true;
        Debug.Log("Jumpscare triggered!");
        
        // Turn on the scary UI screen if it is plugged in!
        if (gameManager != null)
        {
            gameManager.TriggerJumpscareUI(); 
        }
    }
}