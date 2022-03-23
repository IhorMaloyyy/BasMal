using UnityEngine;

public class LargeBasketPowerUp : PowerUp
{
    private GameObject basket;

    private readonly float sizeMultiplier = 1.5f;

    protected override void Start()
    {
        base.Start();

        basket = GameObject.Find("Basket");
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        basket.transform.localScale *= sizeMultiplier;
    }
}
