using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private int score = 0; // The current score



   

    private void SetTextDisplay(bool enabled) {
        // firstMinute.enabled = enabled;
        // secondMinute.enabled = enabled;
        // separator.enabled = enabled;
        // firstSecond.enabled = enabled;
        // secondSecond.enabled = enabled;

        //Use this for a single text object
        //timerText.enabled = enabled;
    }

    public void AddScore(int value)
    {
        score += value; // Increase the score by the given value
        UpdateScore(); // Update the score display
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
        Debug.Log("Score: " + score); // Display the current score in the Unity console
        // You can also update a UI element to display the score, or perform other actions as needed
    }
}
