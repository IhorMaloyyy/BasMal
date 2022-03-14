using UnityEngine;
using System.Collections;

public class BusketLowSpeedPowerUp : PowerUp
{
    private BasketMover basketMoverScript;

    private readonly float speedToDivision = 2f;

    protected override void Start()
    {
        base.Start();

        basketMoverScript = GameObject.Find("Basket").GetComponent<BasketMover>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        SubstractionBasketSpeed();
    }

    private void SubstractionBasketSpeed()
    {
        basketMoverScript.Step /= speedToDivision;
    }
}
