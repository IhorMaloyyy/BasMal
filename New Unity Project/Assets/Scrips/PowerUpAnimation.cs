using UnityEngine;

public class PowerUpAnimation : MonoBehaviour
{
    private float time = 0f;
    private float prefabAmplitude = 0.25f;
    private float movingFrequency = 2;
    private float offset = 0;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        time += Time.deltaTime;
        offset = prefabAmplitude * Mathf.Sin(time * movingFrequency);

        transform.position = startPosition + new Vector3(0, offset, 0);
    }
}
