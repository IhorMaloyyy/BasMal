using UnityEngine;

public class BallCustomization : MonoBehaviour
{
    [SerializeField] private GameObject[] ballPrefabs;

    public void SetBallPrefab(int ballID)
    {
        ballPrefabs[ballID].SetActive(true);
    }
}
