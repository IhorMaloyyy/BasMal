using UnityEngine;
using UnityEngine.UI;

public class BallCustomization : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Toggle[] colorToggles;
    [SerializeField] private Material[] ballMaterials;

    private Renderer ballRenderer;


    private void Start()
    {
        ballRenderer = ballPrefab.GetComponentInChildren<Renderer>();
    }

    public void SetBallMaterial()
    {
        for (int i = 0; i < colorToggles.Length; i++)
        {
            if (colorToggles[i].isOn)
            {
                ballRenderer.material = ballMaterials[i];
            }
        }
    }
}
