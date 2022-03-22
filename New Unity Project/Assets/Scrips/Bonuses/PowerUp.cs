using UnityEngine;

public class PowerUp : MonoBehaviour
{
    protected SpawnManager spawnManagerScript;

    protected virtual void Start()
    {
        spawnManagerScript = GameObject.Find(nameof(SpawnManager)).GetComponent<SpawnManager>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        spawnManagerScript.IsPowerupOnScene = false;
    }
}
