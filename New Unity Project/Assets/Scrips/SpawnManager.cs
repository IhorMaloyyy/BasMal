using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    private Vector3 spawnPos = new Vector3(0.11f, 10.52f, -34.69f);
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
        {
            BallSpawner();
        }
    }

    private void BallSpawner()
    {
        Instantiate(ballPrefab, spawnPos, ballPrefab.transform.rotation);
    }
}
