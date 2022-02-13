using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    private Vector3 spawnPos = new Vector3(2.375f, 9.995f, -35.106f);
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
