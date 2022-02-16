using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;

    private Vector3 spawnPos = new Vector3(0f, 2.5f, -38.66f);


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
