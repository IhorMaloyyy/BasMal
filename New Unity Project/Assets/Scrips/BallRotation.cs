using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    private BallController ballControllerScript;

    private readonly float rotationSpeed = 20f;
    private readonly float xRotationAngel = 45f;
    private readonly float yRotationAngel = 10f;
    private readonly float zRotationAngel = 10f;

    private void Start()
    {
        ballControllerScript = GameObject.Find("Ball(Clone)").GetComponent<BallController>();
    }

    private void Update()
    {
        if (ballControllerScript.IsBallActive)
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * new Vector3(-xRotationAngel, yRotationAngel, zRotationAngel));
        }
    }
}
