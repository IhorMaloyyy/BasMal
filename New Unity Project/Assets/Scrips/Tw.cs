using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tw : MonoBehaviour
{
    private BallController ballControllerScript;
    private float rotationSpeed = 20f;
    void Start()
    {
        ballControllerScript = GameObject.Find("Ball(Clone)").GetComponent<BallController>();
    }

    void Update()
    {
        if (ballControllerScript.IsBallActive)
        {
            transform.Rotate(new Vector3(-45f, 10f, 10f) * Time.deltaTime * rotationSpeed);
        }
    }
}
