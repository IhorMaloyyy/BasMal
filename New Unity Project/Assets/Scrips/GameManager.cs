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
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject soundXMark;

    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshPro bestScoreText;
    [SerializeField] private TextMeshPro lastScoresText;

    [SerializeField] private Slider volumeSlider;
    
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    private int randomSongIndex;

    private BallController ballControllerScript;
    private ScoreCounter scoreCounterScript;
    private Timer timerScript;

    public int bestScore;
    public int[] lastScores = new int[5];

    public string bestPlayerName;
    public string[] lastPlayerNames = new string[5];

    private bool isGamePaused = false;
    private bool isGameOver = false;


    private void Awake()
    {
        LoadScore();
        bestScoreText.text = "Best Score : " + bestPlayerName + " - " + bestScore;
        lastScoresText.text = $"Ðrevious attempts: \n";

        for (int i = 0; i < lastScores.Length; i++)
        {
            lastScoresText.text += $"{lastScores[i]} - {lastPlayerNames[i]} \n";
        }
    }

    private void Start()
    {
        scoreCounterScript = GameObject.Find("ScoreCounter").GetComponent<ScoreCounter>();
        timerScript = GameObject.Find("Timer").GetComponent<Timer>();
    }

    private void Update()
    {
        if (timerScript.TimeLeft < 0 && !isGameOver)
        {
            GameOver();
            SaveScore();
        }

        if (Input.GetKey(KeyCode.Space) && !ballControllerScript.IsBallActive)
        {
            ChangeProgerssBarColor();
        }

        PauseManager();

        VolumeChecker();
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
        isGameOver = true;

        gameOverScreen.SetActive(true);
        gameOverScoreText.text = "Your score is " + scoreCounterScript.Score;
        scoreCounterScript.ScoreText.enabled = false;
        timerScript.TimerText.enabled = false;
        Destroy(spawnManager);

        DisableControl();

        SetBestScore();
        SetLastScores();

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

    private void SetLastScores()
    {
        for (int i = lastScores.Length - 1; i > 0; i--)
        {
            lastScores[i] = lastScores[i - 1];
            lastPlayerNames[i] = lastPlayerNames[i - 1];
        }

        lastScores[0] = scoreCounterScript.Score;
        lastPlayerNames[0] = MainMenuManager.Instance.playerName;
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

    private void PauseManager()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused) { ResumeGame(); }

            else { PauseMenu(); }
        }   

    }
    
    private void PauseMenu()
    {
        isGamePaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        audioSource.Pause();
    }
    
    public void ResumeGame()
    {
        isGamePaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        audioSource.Play();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }

    public void SwitchVolume()
    {
        if (audioSource.volume == 0)
        {
            audioSource.volume = 0.05f;
        }
        else 
        { 
            audioSource.volume = 0;
        }
    }

    private void VolumeChecker()
    {
        volumeSlider.value = audioSource.volume;
        if (audioSource.volume == 0)
        {
            soundXMark.SetActive(true);
        }
        else
        {
            soundXMark.SetActive(false);
        }
    }

    public void VolumeScale()
    {
        audioSource.volume = volumeSlider.value;
    }

    private void RandomStartSong()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();

        randomSongIndex = Random.Range(0, audioClips.Length);
        audioSource.clip = audioClips[randomSongIndex];
        audioSource.Play();
    }





    [System.Serializable]

    class SaveData
    {
        public int bestScoreSave;
        public int[] lastScoresSave = new int[5];

        public string playerNameSave;
        public string[] lastPlayerNamesSave = new string[5];
    }

    public void SaveScore()
    {
        SaveData data = new SaveData
        {
            bestScoreSave = bestScore,
            playerNameSave = bestPlayerName,

            lastScoresSave = lastScores,
            lastPlayerNamesSave = lastPlayerNames,
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
            bestPlayerName = data.playerNameSave;

            lastScores = data.lastScoresSave;
            lastPlayerNames = data.lastPlayerNamesSave;
        }
    }

}
