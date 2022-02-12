using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void LateUpdate()
    {
        transform.rotation = player.transform.rotation;
    }
}
