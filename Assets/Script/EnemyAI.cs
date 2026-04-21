/*using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Hunting Settings")]
    public Transform targetDoor; // The exact location the enemy is walking towards
    public float creepSpeed = 1.0f; // How fast the enemy moves

    void Update()
    {
        // Failsafe: If we forgot to assign a door, do nothing so the game doesn't crash
        if (targetDoor == null) return;

        // Calculate how far to move this specific frame
        float step = creepSpeed * Time.deltaTime;

        // Move the enemy slowly from its current position directly toward the door
        transform.position = Vector3.MoveTowards(transform.position, targetDoor.position, step);
    }
}*/

using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Hunting Settings")]
    public Transform targetDoor;
    public Transform player;
    public float creepSpeed = 1.0f;
    public float jumpscareDistance = 0.5f;

    private bool hasTriggeredJumpscare = false;

    // Reference to your GameManager
    public GameManager gameManager;

    void Update()
    {
        // Prevent jumpscares before game starts or after game ends
        if (gameManager == null || !gameManager.gameStarted || gameManager.gameEnded)
            return;

        if (targetDoor == null) return;

        float step = creepSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetDoor.position, step);

        if (!hasTriggeredJumpscare && player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= jumpscareDistance)
            {
                TriggerJumpscare();
            }
        }
    }

    void TriggerJumpscare()
    {
        hasTriggeredJumpscare = true;

        Debug.Log("Jumpscare triggered!");

        // Add your jumpscare effects here (UI flash, sound, animation, etc.)
    }
}
