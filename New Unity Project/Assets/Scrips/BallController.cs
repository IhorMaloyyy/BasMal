using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody playerRb;
    
    [SerializeField] private float ballForce = 4.0f;

    [SerializeField] private float rotationSpeed;

    [SerializeField] private GameObject mainCamera;

    public bool isBallActive; 
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        mainCamera = GameObject.Find("Main Camera");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isBallActive)
        {
            BallThrowing();
        }

        BallRotation();
    }

    private void BallThrowing()
    {
        playerRb.isKinematic = false;
        playerRb.AddForce(transform.forward * ballForce, ForceMode.Impulse);
        isBallActive = true;
    }

    private void BallRotation()
    {
        transform.rotation = mainCamera.transform.rotation;
    }

}
