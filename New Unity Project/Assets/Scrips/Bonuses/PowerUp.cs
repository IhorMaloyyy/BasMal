using UnityEngine;

public class PowerUp : MonoBehaviour
{

    protected virtual void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
