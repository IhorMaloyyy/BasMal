using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRb;

    private readonly float ballForceForward = 20f;
    [SerializeField] private float ballForceUp = 7.5f;

    private GameObject mainCamera;

    private bool isBallActive;

    public bool IsBallActive 
    {
       get
       {
           return isBallActive;
       }
    }
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
        isBallActive = true;
        ballRb.isKinematic = false;
        ballRb.AddForce(transform.up * ballForceUp, ForceMode.Impulse);
        ballRb.AddForce(transform.forward * ballForceForward, ForceMode.Impulse);
    }
    private void BallRotation()
    {
        transform.rotation = mainCamera.transform.rotation;
    }

}
