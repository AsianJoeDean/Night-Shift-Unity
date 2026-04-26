using UnityEngine;
using TMPro; 
using UnityEngine.SceneManagement; // NEW: Required to load scenes!

public class NightTimer : MonoBehaviour
{
    [Header("Shift Settings")]
    public float shiftLengthInSeconds = 120f; 
    private float timer = 0f;
    private bool hasWon = false;

    [Header("UI Elements")]
    public TextMeshProUGUI winText; 
    public GameObject restartButton; // NEW: Slot for your new button

    void Start()
    {
        if (winText != null) winText.gameObject.SetActive(false);
        if (restartButton != null) restartButton.SetActive(false); // Hide button at start
    }

    void Update()
    {
        if (hasWon) return; 

        timer += Time.deltaTime;

        if (timer >= shiftLengthInSeconds)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        hasWon = true;
        
        if (winText != null) winText.gameObject.SetActive(true);
        if (restartButton != null) restartButton.SetActive(true); // Show button on win!

        Time.timeScale = 0f; 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // NEW: The function the button will trigger
    public void RestartFromWin()
    {
        Time.timeScale = 1f; // CRITICAL: Unfreeze the universe before reloading!
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}