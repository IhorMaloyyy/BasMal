using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float speed = 4.0f;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        float playerInput = Input.GetAxis("Horizontal");
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            BallThrowing();
        }
    }

    private void BallThrowing()
    {
        playerRb.isKinematic = false;
        playerRb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
