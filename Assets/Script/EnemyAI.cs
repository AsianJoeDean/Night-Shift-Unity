using UnityEngine;

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
}