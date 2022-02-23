using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float timeLeft = 60f;

    public float TimeLeft
    {
        get
        {
            return timeLeft;
        }
        set
        {
            timeLeft = value;
        }
    }
    public TextMeshProUGUI TimerText { get { return timerText; } set { timerText = value; } }

    private void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Round(timeLeft);
    }
}
