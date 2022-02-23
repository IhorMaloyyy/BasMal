using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] powerupPrefab;

    private Vector3 ballSpawnPos = new Vector3(0f, 2.5f, -38.66f);

    private readonly float powerupXRange = 15.0f;
    private readonly float powerupYSpawnPos = 10.0f;
    private readonly float powerupZSpawnPos = -24.59f;

    private readonly float startDelay = 10.0f;
    private readonly float repeatDelay = 5.0f;

    private bool isPowerupOnScene = false;
    
    public bool IsPowerupOnScene { get{ return isPowerupOnScene; } set { isPowerupOnScene = value; } }

    private void Start()
    {
        InvokeRepeating(nameof(PowerupSpawner), startDelay, repeatDelay);
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
        {
            BallSpawner();
        }
    }

    private void BallSpawner()
    {
        Instantiate(ballPrefab, ballSpawnPos, ballPrefab.transform.rotation);
    }

    private void PowerupSpawner()
    {
        int powerupIndex = Random.Range(0, powerupPrefab.Length);
        float xRandomPos = Random.Range(-powerupXRange, powerupXRange);

        Vector3 spawnPos = new Vector3(xRandomPos, powerupYSpawnPos, powerupZSpawnPos);
        if (!isPowerupOnScene)
        {
            Instantiate(powerupPrefab[powerupIndex], spawnPos, powerupPrefab[powerupIndex].transform.rotation);
        }
        isPowerupOnScene = true;
    }
}
