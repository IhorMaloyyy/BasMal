using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private readonly float rotationSpeed = 1.5f;
    private readonly float maxAngle = 40f;
    private float yAngle;

    void Update()
    {
        RotateInLimits();
    }

    private void RotateInLimits()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        yAngle = Mathf.Clamp(yAngle + horizontalInput * rotationSpeed, -maxAngle, maxAngle);
        transform.eulerAngles = new Vector3(-20, yAngle, 0);
    }
}