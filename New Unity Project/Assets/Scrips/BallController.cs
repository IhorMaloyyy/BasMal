using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody playerRb;
    
    [SerializeField] private float ballForce = 4.0f;

    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float playerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, playerInput * rotationSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BallThrowing();
        }
    }

    private void BallThrowing()
    {
        playerRb.isKinematic = false;
        playerRb.AddForce(transform.forward * ballForce, ForceMode.Impulse);
    }

}
