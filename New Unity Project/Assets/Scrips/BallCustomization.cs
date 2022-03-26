using UnityEngine;

public class BallCustomization : MonoBehaviour
{
    [SerializeField] private FlexibleColorPicker flexibleColorPicker;
    [SerializeField] private Material ballMaterial;

    private void Update()
    {
        ballMaterial.color = flexibleColorPicker.color;
    }
}
