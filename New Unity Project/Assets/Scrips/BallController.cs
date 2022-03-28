using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballRb;

    private GameObject mainCamera;

    private readonly float ballForceForward = 10f;
    private readonly float ballForceUp = 8f;
    private readonly float maxMultiplierValue = 3f;

    private float forceMultiplier;

    private bool isBallActive;

    public bool IsBallActive { get { return isBallActive; } }

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
        ballRb.AddRelativeForce(0, ballForceUp * forceMultiplier, ballForceForward * forceMultiplier, ForceMode.Impulse);
    }

    private void BallRotation()
    {
        transform.rotation = mainCamera.transform.rotation;
    }

}
