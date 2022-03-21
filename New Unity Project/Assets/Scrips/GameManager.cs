using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject spawnManager;

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

    [System.Serializable]

    class SaveData
    {
        public int bestScoreSave;
        public string playerName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.bestScoreSave = bestScore;
        data.playerName = bestPlayerName;

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
