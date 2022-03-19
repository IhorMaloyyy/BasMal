using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject basket;

    private BasketMover basketMoverScript;

    private Vector3 basketDefaultScale = new Vector3(1, 1, 1);

    private int score;
    private readonly float defaultBasketSpeed = 0.003f;

    private AudioSource ballSound;
    [SerializeField] AudioClip ballHit;

    public int Score { get { return score; } set { score = value; } }
    public TextMeshProUGUI ScoreText { get { return scoreText; } set { scoreText = value; } }

    private void Start()
    {
        score = 0;
        basketMoverScript = GameObject.Find("Basket").GetComponent<BasketMover>();

        ballSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        AddScore();
        ballSound.PlayOneShot(ballHit);
        Destroy(other.gameObject);
        SetDefaultBasketSpeed();
        SetDefaultBasketScale();
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

    private void SetDefaultBasketScale()
    {
        basket.transform.localScale = basketDefaultScale;
    }
}
