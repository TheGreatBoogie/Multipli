using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTimeInSeconds = 10f; // Default countdown time
    private float currentTime;
    private bool isCountingDown = false;

    public UnityEvent onCountdownFinished; // Event to subscribe to for countdown completion

    private void Start()
    {
        ResetTimer(); // Initialize timer
    }

    // Start the countdown
    public void StartCountdown()
    {
        if (!isCountingDown)
        {
            currentTime = countdownTimeInSeconds;
            StartCoroutine(CountdownRoutine());
        }
    }

    // Coroutine for countdown logic
    private IEnumerator CountdownRoutine()
    {
        isCountingDown = true;
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(1f);
            currentTime--;
            Debug.Log("Countdown: " + currentTime); // Optional: Update UI here
        }
        isCountingDown = false;
        onCountdownFinished.Invoke(); // Notify subscribers that countdown finished
    }

    // Pause the countdown
    public void PauseCountdown()
    {
        StopCoroutine(CountdownRoutine());
        isCountingDown = false;
    }

    // Resume the countdown
    public void ResumeCountdown()
    {
        if (!isCountingDown)
        {
            StartCoroutine(CountdownRoutine());
        }
    }

    // Reset the countdown timer
    public void ResetTimer()
    {
        currentTime = countdownTimeInSeconds;
        isCountingDown = false;
    }

    // Optionally, create a method to check the current time or expose a property
    public float GetCurrentTime()
    {
        return currentTime;
    }
}