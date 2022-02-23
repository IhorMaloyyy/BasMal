using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] powerupPrefab;

    private Vector3 ballSpawnPos = new Vector3(0f, 2.5f, -38.66f);

    private float powerupXRange = 15.0f;
    private float powerupYSpawnPos = 10.0f;
    private float powerupZSpawnPos = -24.59f;

    private float startDelay = 2;
    private float repeatDelay = 5;

    private void Start()
    {
        InvokeRepeating("PowerupSpawner", startDelay, repeatDelay);
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

        Instantiate(powerupPrefab[powerupIndex], spawnPos, powerupPrefab[powerupIndex].transform.rotation);
    }
}
