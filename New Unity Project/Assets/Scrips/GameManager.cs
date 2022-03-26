using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject spawnManager;
    [SerializeField] private GameObject progressBar;

    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private BallController ballControllerScript;
    private ScoreCounter scoreCounterScript;
    private Timer timerScript;

    public int bestScore;
    public string bestPlayerName;

    private void Awake()
    {
        LoadScore();
        bestScoreText.text = "Best Score : " + bestPlayerName + " - " + bestScore;
    }

    private void Start()
    {
        scoreCounterScript = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();
        timerScript = GameObject.Find("Timer").GetComponent<Timer>();
        
    }

    private void Update()
    {
        if (timerScript.TimeLeft < 0)
        {
            GameOver();
        }

        if (Input.GetKey(KeyCode.Space) && !ballControllerScript.IsBallActive)
        {
            ChangeProgerssBarColor();
        }
    }

    private void FixedUpdate()
    {
        if (timerScript.TimeLeft > 0)
        {
            ChangeProgressBarWidth();
        }
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverScoreText.text = "Your score is " + scoreCounterScript.Score;
        scoreCounterScript.ScoreText.enabled = false;
        timerScript.TimerText.enabled = false;
        Destroy(spawnManager);

        DisableControl();

        SetBestScore();
    }

    private void SetBestScore()
    {
        if(bestScore < scoreCounterScript.Score)
        {
            bestScore = scoreCounterScript.Score;
            bestPlayerName = MainMenuManager.Instance.playerName;
            SaveScore();
        }
    }

    private void DisableControl()
    {
        mainCamera.GetComponent<CameraRotation>().enabled = false;
    }

    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ChangeProgressBarWidth()
    {
        ballControllerScript = GameObject.Find("Ball(Clone)").GetComponent<BallController>();
        progressBar.transform.localScale = new Vector2(1, ballControllerScript.ForceMultyplier * 10);
    }

    private void ChangeProgerssBarColor()
    {
        progressBar.GetComponent<Image>().color = new Color(ballControllerScript.ForceMultyplier / 3, 1, 0, 1);
    }

    [System.Serializable]

    class SaveData
    {
        public int bestScoreSave;
        public string playerName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData
        {
            bestScoreSave = bestScore,
            playerName = bestPlayerName
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            bestScore = data.bestScoreSave;
            bestPlayerName = data.playerName;
        }
    }

}
