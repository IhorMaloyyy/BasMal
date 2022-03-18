using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    
    private BallController ballControllerScript;
    private float rotationSpeed = 20f;
    private float xRotationAngel = 45f;
    private float yRotationAngel = 10f;
    private float zRotationAngel = 10f;
    void Start()
    {
        ballControllerScript = GameObject.Find("Ball(Clone)").GetComponent<BallController>();
    }

    void Update()
    {
        if (ballControllerScript.IsBallActive)
        {
            transform.Rotate(new Vector3(-xRotationAngel, yRotationAngel, zRotationAngel) * Time.deltaTime * rotationSpeed);
        }
    }
}
