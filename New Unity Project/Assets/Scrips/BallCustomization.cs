using UnityEngine;

public class BallCustomization : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Material[] ballMaterials;

    private Renderer ballRenderer;


    private void Start()
    {
        ballRenderer = ballPrefab.GetComponentInChildren<Renderer>();
    }

    public void SetBallMaterial()
    {
        ballRenderer.material = ballMaterials[1];
    }
}
