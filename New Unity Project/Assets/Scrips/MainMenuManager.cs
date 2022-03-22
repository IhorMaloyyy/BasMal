using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    public static MainMenuManager Instance;
    public TextMeshProUGUI bestScoreText;

    public string playerName;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        GameManager data = new GameManager();
        data.LoadScore();
        bestScoreText.text = $"Best Score: {data.bestPlayerName} - {data.bestScore}";

    }

    public void SetPlayerName()
    {
        playerName = inputField.text;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
