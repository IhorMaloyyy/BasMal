using UnityEngine;

public class BasketMover : MonoBehaviour
{
    private float basketSpeed = 0.1f;
    private float xBound = 48.0f;

    private void FixedUpdate()
    {
        MoveLeft(basketSpeed);
    }


    private void MoveLeft(float speed)
    {
        transform.Translate(Vector3.left * speed);
    }
    
}
