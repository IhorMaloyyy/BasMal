using UnityEngine;

public class BasketMover : MonoBehaviour
{
    private Vector3 startPosition = new Vector3(15, 10, -7.25f);
    private Vector3 endPosition = new Vector3(-15, 10, -7.25f);

    private float step = 0.002f;
    private float progress;
    private readonly float minProgress = 0f;
    private readonly float maxProgress = 1f;

    private bool onEndPosition;

    public float Step
    { 
        get 
        { 
            return step; 
        } 
        set 
        { 
            step = value; 
        } 
    }

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
