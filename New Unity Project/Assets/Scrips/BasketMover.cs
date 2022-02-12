using UnityEngine;

public class BasketMover : MonoBehaviour
{
    private Vector3 startPosition = new Vector3(20, 0, -10);
    private Vector3 endPosition = new Vector3(-20, 0, -10);

    private float step = 0.003f;
    private float progress;
    private float minProgress = 0f;
    private float maxProgress = 1f;

    private bool onEndPosition;


    private void FixedUpdate()
    {
        if (!onEndPosition)
        {
            MoveLeft(step);
        }
        else
        {
            MoveLeft(-step);
        }
        CheckProgress();
    }

    private void MoveLeft(float step)
    {
        transform.position = Vector3.Lerp(startPosition, endPosition, progress);
        progress += step;
    }

    private void CheckProgress()
    {
        if (progress > maxProgress)
        {
            onEndPosition = true;
        }
        else if (progress < minProgress)
        {
            onEndPosition = false;
        }

    }
}
