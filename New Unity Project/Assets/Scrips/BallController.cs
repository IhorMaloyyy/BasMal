using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRb;

    private  float ballForceForward = 20f;
    [SerializeField] private float ballForceUp = 7.5f;
    [SerializeField] private float forceMultiplier = 1;
    private float maxMultiplierValue = 3f;


    private GameObject mainCamera;

    private bool isBallActive;

    public bool IsBallActive { get; }
    

    public float ForceMultyplier
    {
        get { return forceMultiplier; } 
        set
        {
            if (forceMultiplier > maxMultiplierValue){ forceMultiplier = maxMultiplierValue; }
            else { forceMultiplier = value; }
        }
    }

    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        mainCamera = GameObject.Find("Main Camera");
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isBallActive)
        {
            ForceMultyplier += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space) && !isBallActive)
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
        ballRb.AddForce(transform.forward * (ballForceForward * forceMultiplier), ForceMode.Impulse);
    }
    private void BallRotation()
    {
        transform.rotation = mainCamera.transform.rotation;
    }

}
