using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameOverManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject gameOverCanvas;
    
    [Header("Audio")]
    public AudioSource jumpscareSound; // NEW: The sound player!

    void Start()
    {
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }
    }

    public void TriggerJumpscareUI()
    {
        gameOverCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // NEW: Play the scream!
        if (jumpscareSound != null)
        {
            jumpscareSound.Play();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}