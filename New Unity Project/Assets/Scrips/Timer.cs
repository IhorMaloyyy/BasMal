using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float timeLeft = 60f;

    private void Update()
    {
        UpdateTimer();

        if(timeLeft < 0f)
        {
            LoadCurrentScene();
        }
    }

    private void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Round(timeLeft);
    }

    private void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
