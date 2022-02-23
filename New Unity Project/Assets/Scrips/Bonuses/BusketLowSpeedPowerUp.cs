using UnityEngine;

public class BusketLowSpeedPowerUp : PowerUp
{
    private BasketMover basketMoverScript;

    private readonly float speedToSubstract = 0.0015f;

    private void Start()
    {
        basketMoverScript = GameObject.Find("Basket").GetComponent<BasketMover>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        SubstractionBasketSpeed(speedToSubstract);
    }

    private void SubstractionBasketSpeed(float speedToSubstract)
    {
        basketMoverScript.Step -= speedToSubstract;
    }
}
