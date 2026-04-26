using UnityEngine;
using TMPro; // Needed for the Text

public class GameTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    public float shiftLength = 120f; // Total seconds to survive (e.g., 120 = 2 minutes)
    public TextMeshProUGUI timerText; // Drag your TimerText here
    
    private bool hasWon = false;

    void Update()
    {
        // Only count down if the timer is above zero and we haven't won yet
        if (shiftLength > 0 && !hasWon)
        {
            shiftLength -= Time.deltaTime;

            // Format the time into Minutes:Seconds (e.g., 01:45)
            float minutes = Mathf.FloorToInt(shiftLength / 60);
            float seconds = Mathf.FloorToInt(shiftLength % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // Check if time ran out!
            if (shiftLength <= 0)
            {
                shiftLength = 0;
                timerText.text = "00:00";
                hasWon = true;
                
                TriggerWin();
            }
        }
    }

    void TriggerWin()
    {
        // Whatever code you use to show your win screen goes here!
        // For example: winCanvas.SetActive(true);
        Debug.Log("6 AM! You survived!");
    }
}