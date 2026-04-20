using UnityEngine;
using System.Collections; 

public class EnemyAI : MonoBehaviour
{
    [Header("Hunting Settings")]
    public Transform targetDoor; 
    public DoorController doorScript; 
    public float creepSpeed = 1.0f; 
    
    [Header("Attack Settings")]
    public float attackDistance = 2.0f; // Slightly increased so the cube doesn't clip the wall
    public float waitTimeAtDoor = 3.0f; 
    
    private Vector3 startPosition; 
    private bool isWaiting = false; 

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (targetDoor == null || isWaiting) return;

        // THE FIX: Create "flat" versions of the positions that lock the Y-axis to 0
        Vector3 enemyFlatPos = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 doorFlatPos = new Vector3(targetDoor.position.x, 0, targetDoor.position.z);

        // Now we measure the distance using the flat floor coordinates
        float distanceToDoor = Vector3.Distance(enemyFlatPos, doorFlatPos);

        if (distanceToDoor <= attackDistance)
        {
            if (doorScript.isOpen)
            {
                Debug.Log("GAME OVER! You got jump-scared!");
                isWaiting = true; 
            }
            else
            {
                StartCoroutine(WaitAndLeave());
            }
        }
        else
        {
            // Keep walking
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
}