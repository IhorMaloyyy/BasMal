using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRb;
    
    private readonly float ballForce = 30f;

    private GameObject mainCamera;

    private bool isBallActive; 
    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        mainCamera = GameObject.Find("Main Camera");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isBallActive)
        {
            BallThrowing();
        }
    }

    private void LateUpdate()
    {
        BallRotation();
    }

    private void BallThrowing()
    {
        ballRb.isKinematic = false;
        ballRb.AddForce(transform.forward * ballForce, ForceMode.Impulse);
        isBallActive = true;
    }

    private void BallRotation()
    {
        transform.rotation = mainCamera.transform.rotation;
    }

}
