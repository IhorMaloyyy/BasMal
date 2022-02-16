using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    void Update()
    {
        float playerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, playerInput * rotationSpeed * Time.deltaTime, Space.World);
    }
}
