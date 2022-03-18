using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject spawnManager;

    private ScoreCounter scoreCounterScript;
    private Timer timerScript;

    private void Start()
    {
        scoreCounterScript = GameObject.Find("Cylinder").GetComponent<ScoreCounter>();
        timerScript = GameObject.Find("Timer").GetComponent<Timer>();
    }

    private void Update()
    {
        if(timerScript.TimeLeft < 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverScoreText.text = "Your score is " + scoreCounterScript.Score;
        scoreCounterScript.ScoreText.enabled = false;
        timerScript.TimerText.enabled = false;
        spawnManager.SetActive(false);

        DisableControl();
    }

    private void DisableControl()
    {
        mainCamera.GetComponent<CameraRotation>().enabled = false;
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
