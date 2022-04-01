using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject[] powerupPrefab;

    private Vector3 ballSpawnPos = new Vector3(0f, 2.5f, -38.66f);

    private readonly float powerupXRange = 7.0f;
    private readonly float powerupYSpawnPos = 12.0f;
    private readonly float powerupZSpawnPos = -27.0f;

    private readonly float startDelay = 10.0f;
    private readonly float repeatDelay = 10.0f;

    private bool isPowerupOnScene = false;

    [SerializeField]private bool[] activePowerUp = new bool[3];

    public bool[] ActivePowerUp { get { return activePowerUp; } set { activePowerUp = value; } }
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

        if (!isPowerupOnScene && !activePowerUp[powerupIndex])
        {
            Instantiate(powerupPrefab[powerupIndex], spawnPos, powerupPrefab[powerupIndex].transform.rotation);
            activePowerUp[powerupIndex] = true;
            isPowerupOnScene = true;
        }
    }
}
