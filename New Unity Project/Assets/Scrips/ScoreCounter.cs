using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;

    public int Score { get { return score; } set { score = value; } }
    public TextMeshProUGUI ScoreText { get { return scoreText; } set { scoreText = value; } }

    private void Start()
    {
        score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        AddScore();
        Destroy(other.gameObject);
    }

    private void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
