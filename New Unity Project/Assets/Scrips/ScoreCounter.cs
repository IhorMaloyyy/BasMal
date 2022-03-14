using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private BasketMover basketMoverScript;

    private int score;
    private readonly float defaultBasketSpeed = 0.003f;

    public int Score { get { return score; } set { score = value; } }
    public TextMeshProUGUI ScoreText { get { return scoreText; } set { scoreText = value; } }

    private void Start()
    {
        score = 0;
        basketMoverScript = GameObject.Find("Basket").GetComponent<BasketMover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        AddScore();
        Destroy(other.gameObject);
        SetDefaultBasketSpeed();
    }

    private void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    private void SetDefaultBasketSpeed()
    {
        basketMoverScript.Step = defaultBasketSpeed;
    }
}
