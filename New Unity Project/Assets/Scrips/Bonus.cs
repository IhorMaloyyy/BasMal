using UnityEngine;

public class Bonus : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
