using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject basket;

    private BasketMover basketMoverScript;

    private Vector3 basketDefaultScale = new Vector3(1f, 1f, 1f);

    private int score;
    private readonly float defaultBasketSpeed = 0.002f;

    [SerializeField] private AudioClip ballHit;
    private AudioSource ballSound;
    private readonly float volumeScale = 0.1f;

    private SpawnManager spawnManager;

    public int Score { get { return score; } set { score = value; } }
    public TextMeshProUGUI ScoreText { get { return scoreText; } set { scoreText = value; } }

    private void Start()
    {
        score = 0;
        basketMoverScript = GameObject.Find("Basket").GetComponent<BasketMover>();

        ballSound = GetComponent<AudioSource>();

        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        AddScore();
        ballSound.PlayOneShot(ballHit, volumeScale);
        SetDefaultBasketSpeed();
        SetDefaultBasketScale();
        DisablePowerUpsActivity();
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

    private void DisablePowerUpsActivity()
    {
        for (int i = 0; i < spawnManager.ActivePowerUp.Length; i++)
        {
            spawnManager.ActivePowerUp[i] = false;
        }
    }
}
