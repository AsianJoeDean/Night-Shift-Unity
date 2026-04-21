using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Game State")]
    public bool gameStarted = false;
    public bool gameEnded = false;

    [Header("UI References")]
    public GameObject mainMenuUI;
    public GameObject gameplayUI;
    public GameObject gameOverUI;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        ShowMainMenu();
    }

    // ---------------------------
    // MAIN MENU
    // ---------------------------
    public void ShowMainMenu()
    {
        gameStarted = false;
        gameEnded = false;

        if (mainMenuUI != null) mainMenuUI.SetActive(true);
        if (gameplayUI != null) gameplayUI.SetActive(false);
        if (gameOverUI != null) gameOverUI.SetActive(false);

        Time.timeScale = 1f;
    }

    // ---------------------------
    // START GAME
    // ---------------------------
    public void StartGame()
    {
        gameStarted = true;
        gameEnded = false;

        if (mainMenuUI != null) mainMenuUI.SetActive(false);
        if (gameplayUI != null) gameplayUI.SetActive(true);
        if (gameOverUI != null) gameOverUI.SetActive(false);

        Debug.Log("Game Started");
    }

    // ---------------------------
    // END GAME
    // ---------------------------
    public void EndGame()
    {
        gameEnded = true;
        gameStarted = false;

        if (gameplayUI != null) gameplayUI.SetActive(false);
        if (gameOverUI != null) gameOverUI.SetActive(true);

        Debug.Log("Game Ended");
    }

    // ---------------------------
    // RESTART GAME
    // ---------------------------
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ---------------------------
    // RETURN TO MAIN MENU
    // ---------------------------
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ---------------------------
    // QUIT GAME
    // ---------------------------
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}