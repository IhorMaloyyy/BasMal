using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;

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
